create or replace procedure room_option(cgpa IN float)
is 
n varchar(10);
begin
select driver_id into n from person where person.name=namee;
dbms_output.put_line(n);
end;
/



-- NOT OUR CODE
create or replace procedure try(namee IN varchar)
is
n person%rowtype;
begin
select * into n from person where person.name=namee;

end;
/