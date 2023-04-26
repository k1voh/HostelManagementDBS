
/* TRIGGER TO CALCULATE TOTAL_FEES */ 

create or replace trigger totfee
after insert on fees
begin
    if inserting then
        update fees set total_fee = hostel_fee + mess_fee;
    end if;
end;
/