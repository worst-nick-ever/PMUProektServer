metadata=res://*/Models.SudokuDatabse.csdl|res://*/Models.SudokuDatabse.ssdl|res://*/Models.SudokuDatabse.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=PETKO-PC;initial catalog=KursovProektPMU;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;

*/

CREATE TABLE Account(
ID INT IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(20) not null unique,
Password nvarchar(20) not null);

Create table Highscore(
ID int identity(1,1) primary key,
UserID int foreign key references Account(ID),
Difficulty nvarchar(7) not null,
Score bigint not null);

Create table Sudoku(
ID int identity(1,1) primary key,
Difficulty nvarchar(7) not null,
LRU int default 0,
Puzzle nvarchar(81) not null);

Create table Challenge(
ID int identity(1,1) primary key,
ChallengerID int foreign key references Account(ID),
ChallengedID int foreign key references Account(ID),
SudokuID int foreign key references Sudoku(ID),
Accepted bit default 0,
Completed bit default 0);

Insert into Account values ('Firelord', '12345'),
 ('Near', '54321'),
 ('Ivan', '11111'),
 ('Gosho', '22222');
 
 INSERT INTO SUDOKU VALUES ('EASY', 0, 'i0bhefd00000000b0h0fh0000ce00f0h000dceg000ahbd000b0c00fd0000ge0g0c00000000eagdf0c'),
 ('EASY', 0, '0a000b00fg00c0i000f0dah0g00d0e0ic000i0a0e0d0h000dg0e0i00g0cdh0e000i0h00ah00e000d0'),
 ('EASY', 0, '00h0000idid0h0000aag000eb0f00i00d0b0dhe000agi0b0e00d00h0gc000dbc0000a0fgbe0000i00'),
 ('EASY', 0, '00c000i00ih000cd0a0000fi0e0h0gb0af00c0b0i0h0g00ac0he0b0c0fd0000d0fa000bi00h000a00'),
 ('EASY', 0, 'h000f00000000ebdh00ebc000i0ih0000c0ea0ce0db0ie0g0000dh0g000eia00afib00000000a000c'),
 ('MEDIUM', 0, 'g00d000i0b000ca000d0aeg0f00e0000g0000h0i0e0d0000h0000e00i0efd0g000ai000f0a000d00c'),
 ('MEDIUM', 0, '00dch0f0i0ga00i0000c00f00b00000000a0d0c000i0h0a00000000e00g00i0000i00af0h0f0abg00'),
 ('MEDIUM', 0, 'h0g0dab00a00e00h00000000ea00beihd000000g0f000000acedi00da00000000h00i00g00bda0i0c'),
 ('MEDIUM', 0, '0000000df0e00f00c0b0f0hae00000da0g0i0a00000b0d0h0ci00000ghe0c0d0h00i00g0ef0000000'),
 ('MEDIUM', 0, '00ei000hagh000a0cd000hg0e00i0d00e0000g00000d0000d00c0h00b0ig000hf0c000igei000hd00'),
 ('HARD', 0, '000c00i00000g00f00a0h00000e0feh0ca0dh0000000fd0cf0geb0e00000c0b00b00h00000a00e000'),
 ('HARD', 0, 'f0000000000eg00d000a0e0c0f000b0000iaa0g0c0h0ehf0000g000i0b0d0a000h00ai0000000000f'),
 ('HARD', 0, 'b0de00f0000000000e00ad0h000g00a00e000h0bef0d000e00i00b000g0ea00a0000000000g00db0c'),
 ('HARD', 0, '0f000e000ice00g0000a0000g000bde0000i00c0i0h00a0000cbg000i0000d0000a00efb000g000h0'),
 ('HARD', 0, '0i0d00hc0a0g00i0000cb00f0i000a0b000h000000000g000e0b000a0b00cg0000h00i0f0de00g0h0'),
 ('EVIL', 0, 'da0000i0000b0g00000ec00b0000h0c0000b0b00i00d0c0000a0g0000e00fc00000a0d0000d0000ia'),
 ('EVIL', 0, '00ihb000dabe0f000000000000g0000gf0c000h000f000c0id0000e000000000000a0ihbh000ice00'),
 ('EVIL', 0, '00000c00dbe000000c0c00ea0h000b0d00g0000c0f0000d00b0h000i0ag00f0d000000cie00f00000'),
 ('EVIL', 0, '0000c000a0cd00000g0a000h0c000000ef0b00g000e00b0ag000000b0d000i0d00000ch0e000i0000'),
 ('EVIL', 0, '00000f000e00ih000a0cg0d00000a00e00i00gi000ed00h00i00g00000a0fe0f000cd00g000h00000');