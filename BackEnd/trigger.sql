
// TRIGGER TO CALCULATE TOTAL_FEES //

create or replace trigger totfee
after insert on fees
begin
    if inserting then
        update fees set total_fee = hostel_fee + mess_fee;
    end if;
end;
/


// TRIGGER TO CALCULATE MESS CHANGE //

create or replace trigger CHANGE_mess
after update of Mess_id on student
for each row
begin
    if updating then
        update changecounter set counter = counter + 1 where (facility = 'Mess Change');
    end if;
end;
/

--DONT INSERT THE FOLLOWING TRIGGER FOR NOW--

// TRIGGER TO CALCULATE ROOM CHANGE //

create or replace trigger CHANGE_room_B10
after update of room_number on B10
for each row
begin
    if updating then
        update changecounter set counter = counter + 1 where (facility = 'Mess Change');
    end if;
end;
/

-----------------------------------------------
