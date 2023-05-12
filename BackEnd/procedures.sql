create or replace procedure room_option(cgpa IN float)
is 
n varchar(10);
begin
select driver_id into n from person where person.name=namee;
dbms_output.put_line(n);
end;
/

create or replace procedure fresherCG(sem IN int)
is
    n int;
begin
    if sem=1 then
        update student set cgpa=10 where semester=sem;
    end if;
end;
/