create table speak_color(
Score int not null);

create table brain_shift(
Score int not null);

create table color_match(
Score int not null);

insert into 2 values(5000);
insert into brain_shift values(6000);
insert into brain_shift values(7000);
insert into brain_shift values(8000);
insert into brain_shift values(9000);
select top(5) score from color_match order by score desc
