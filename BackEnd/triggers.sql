-- TRIGGER TO CALCULATE TOTAL_FEES 
create or replace trigger totfee
after insert on fees
begin
    if inserting then
        update fees set total_fee = hostel_fee + mess_fee;
    end if;
end;
/


 -- TRIGGER TO CALCULATE MESS CHANGE 
create or replace trigger CHANGE_mess
after update of Mess_id on student
for each row
begin
    if updating then
        update changecounter set counter = counter + 1 where (facility = 'Mess Change');
    end if;
end;
/


-- TRIGGER TO UPDATE OCCUPANCY ON UPDATE OF BLOCK
create or replace trigger updateB10
after update on B10
for each row
begin
    if :old.name='NULL' then
        update hostel set unoccupied = unoccupied-1 where hostel_id = 10;
    end if;
    
    if :new.name='NULL' then
        update hostel set unoccupied = unoccupied+1 where hostel_id = 10;
    end if;
end;
/

create or replace trigger updateB11
after update on B11
for each row
begin
    if :old.name='NULL' then
        update hostel set unoccupied = unoccupied-1 where hostel_id = 11;
    end if;
    
    if :new.name='NULL' then
        update hostel set unoccupied = unoccupied+1 where hostel_id = 11;
    end if;
end;
/

create or replace trigger updateB12
after update on B12
for each row
begin
    if :old.name='NULL' then
        update hostel set unoccupied = unoccupied-1 where hostel_id = 12;
    end if;
    
    if :new.name='NULL' then
        update hostel set unoccupied = unoccupied+1 where hostel_id = 12;
    end if;
end;
/

create or replace trigger updateB20
after update on B20
for each row
begin
    if :old.name='NULL' then
        update hostel set unoccupied = unoccupied-1 where hostel_id = 20;
    end if;
    
    if :new.name='NULL' then
        update hostel set unoccupied = unoccupied+1 where hostel_id = 20;
    end if;
end;
/

create or replace trigger updateB21
after update on B21
for each row
begin
    if :old.name='NULL' then
        update hostel set unoccupied = unoccupied-1 where hostel_id = 21;
    end if;
    
    if :new.name='NULL' then
        update hostel set unoccupied = unoccupied+1 where hostel_id = 21;
    end if;
end;
/
-----------------------------------------------