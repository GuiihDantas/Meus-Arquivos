create table tabela(
id serial primary key,
id_nf int,
id_item int,
cod_prod int,
valor_unit float8,
quantidade int,
desconto int
)

insert into tabela 
(id_nf, id_item, cod_prod, valor_unit, quantidade, desconto)
values (1,1,1,25.00,10,5);

insert into tabela 
(id_nf, id_item, cod_prod, valor_unit, quantidade, desconto)
values (1,2,2,13.50,3);

insert into tabela 
(id_nf, id_item, cod_prod, valor_unit, quantidade)
values (1,3,3,15.50,2),(3,5,2,15.50,3),(16,22,6,15.57,3);

insert into tabela 
(id_nf, id_item, cod_prod, valor_unit, quantidade)
values (1,3,3,15.50,2),(3,5,2,15.50,3),(16,22,6,15.00,3),
(2,5,12,11.50,45),(9,2,8,155.00,12),(16,22,6,15.00,4),
(3,4,3,19.50,24),(14,6,12,22.00,32),(16,22,6,15.00,5),
(14,3,23,18.50,62),(11,98,8,44.00,354),(16,22,6,15.00,6),
(6,2,42,16.50,7),(12,5,7,5.00,35),(16,22,6,15.5,7),
(7,1,53,14.50,27),(6,54,7,2.00,36),(16,22,6,15.2,3),
(8,1,65,15.90,24),(4,6,33,16.00,31),(16,22,6,15.4,6);

insert into tabela 
(id_nf, id_item, cod_prod, valor_unit, quantidade, desconto)
values (1,3,3,15.50,2,50),(3,5,2,15.50,3,20),(16,22,6,15.00,3,3),
(2,5,12,11.50,45,62),(9,2,8,155.00,12,12),(16,22,6,15.00,4,3),
(3,4,3,19.50,24,62),(14,6,12,22.00,32,12),(16,22,6,15.00,5,3),
(14,3,23,18.50,62,62),(11,98,8,44.00,354,12),(16,22,6,15.00,6,3),
(6,2,42,16.50,7,62),(12,5,7,5.00,35,12),(16,22,6,15.5,7,3),
(7,1,53,14.50,27,62),(6,54,7,2.00,36,12),(16,22,6,15.2,3,3),
(8,1,65,15.90,24,62),(4,6,33,16.00,31,12),(16,22,6,15.4,6,3);



"Pesquise os itens que foram vendidos sem desconto. 
As colunas presentes no resultado da consulta são: 
ID_NF, ID_ITEM, COD_PROD E VALOR_UNIT."

select id_nf as nota, id_item as item, cod_prod as produto, valor_unit from tabela 
where desconto is Null;

"Pesquise os itens que foram vendidos com desconto. 
As colunas presentes no resultado da consulta são: 
ID_NF, ID_ITEM, COD_PROD, VALOR_UNIT E O VALOR VENDIDO."

select id, id_nf as nota, id_item as item, cod_prod as produto, 
valor_unit - (valor_unit*(desconto/100)) as Novo_Valor
from tabela
where desconto is Not Null;

"Altere o valor do desconto (para zero) de todos os registros onde este campo é nulo"

"Trigger"
AS
BEGIN
  IF (desconto IS NULL) THEN
    desconto = 0;
END


"Select"
SELECT desconto, COALESCE(desconto, 0) FROM tabela;


"Update"
UPDATE tabela
SET desconto = 0
WHERE desconto is Null;

"Pesquise os itens que foram vendidos. As colunas presentes
no resultado da consulta são: ID_NF, ID_ITEM, COD_PROD, VALOR_UNIT, 
VALOR_TOTAL, DESCONTO, VALOR_VENDIDO."

select id, id_nf as nota, id_item as item, cod_prod as produto, 
(quantidade*(valor_unit) - (valor_unit*(desconto/100)) as Valor_Final
from tabela;

"Pesquise o valor total das NF e ordene o resultado do maior valor para o menor.
 As colunas presentes no resultado da consulta são: ID_NF, VALOR_TOTAL."

select id_nf as nota, quantidade*(valor_unit) as Valor_Final
from tabela
order by Valor_Final;

"Pesquise o valor vendido das NF e ordene o resultado do maior valor para o menor.
 As colunas presentes no resultado da consulta são: ID_NF, VALOR_VENDIDO."

select id_nf as nota, quantidade*(valor_unit) - 
(valor_unit*(desconto/100)) as Valor_Final
from tabela
group by nota
order by Valor_Final desc;

"Consulte o produto que mais vendeu no geral. 
As colunas presentes no resultado da consulta são:
 COD_PROD, QUANTIDADE. Agrupe o resultado da consulta por COD_PROD."

select cod_prod, max(quantidade) as qtde_maxima from tabela
group by cod_prod 
order by qtde_maxima desc;

"Consulte as NF que foram vendidas mais de 10 unidades de pelo menos um produto.
 As colunas presentes no resultado da ID_NF, COD_PROD, 
 QUANTIDADE. Agrupe o resultado da consulta por ID_NF, COD_PROD"

 select id_nf, cod_prod, quantidade from tabela
 where quantidade > 10
 group by id_nf;

"Pesquise o valor total das NF, onde esse valor seja maior que 500,
e ordene o resultado do maior valor para o menor.
As colunas presentes no resultado da consulta são: ID_NF, VALOR_TOT."

select * from tabela limit 10;

select (valor_unit*quantidade) as total, id_nf from tabela
where valor_unit*quantidade > 500
order by id_nf desc;

"Qual o valor médio dos descontos dados por produto. 
As colunas presentes no resultado da consulta são: 
COD_PROD, MEDIA. Agrupe o resultado da consulta por COD_PROD."

select cod_prod, avg(desconto) as media from tabela
group by cod_prod;

"Qual o menor, maior e o valor médio dos descontos dados por produto.
 As colunas presentes no resultado da consulta são: COD_PROD, 
MENOR, MAIOR, MEDIA. Agrupe o resultado da consulta por COD_PROD."

select cod_prod, min(desconto) as menor, max(desconto) as maior, 
avg(desconto) as media from tabela
group by cod_prod;

"Quais as NF que possuem mais de 3 itens vendidos. 
As colunas presentes no resultado da consulta são: 
ID_NF, QTD_ITENS. OBS:: NÃO ESTÁ RELACIONADO 
A QUANTIDADE VENDIDA DO ITEM E SIM A QUANTIDADE DE ITENS POR NOTA FISCAL. 
Agrupe o resultado da consulta por ID_NF."

select id_nf, count(id_item) as qtd_itens from tabela
where quantidade > 3
group by id_nf;


"Crie uma base de dados Universidade com as tabelas a seguir:
Alunos (MAT, nome, endereço, cidade)
Disciplinas (COD_DISC, nome_disc, carga_hor)
Professores (COD_PROF, nome, endereço, cidade)
Turma (COD_DISC, COD_TURMA, COD_PROF, ANO, horário)
COD_DISC referencia Disciplinas
COD_PROF referencia Professores
Histórico (MAT, COD_DISC, COD_TURMA, COD_PROF, ANO, frequência, nota)
MAT referencia Alunos
COD_DISC, COD_TURMA, COD_PROF, ANO referencia Turma"

create table alunos(
mat int primary key,
nome varchar (50),
endereco varchar (100),
cidade varchar (50)
);

create table disciplinas(
  cod_disc int primary key,
  nome_disc varchar (100),
  carga_hor int
);

create table professores(
  cod_prof int primary key,
  nome varchar (100),
  endereco varchar (100),
  cidade varchar (50)
);

create table turma (
  cod_turma int primary key,
  cod_disc int,
  cod_prof int,
  ano int,
  horario varchar (30),
  foreign key (cod_disc)
  references disciplinas(cod_disc),
  foreign key (cod_prof)
  references professores(cod_prof)
);

create table historico(
  cod_hist serial primary key,
  mat int,
  cod_disc int,
  cod_turma int,
  cod_prof int,
  ano int, 
  frequencia float8,
  nota float8,
  foreign key (mat) 
  references alunos (mat),
  foreign key (cod_turma)
  references turma(cod_turma)
);

"INSIRA OS SEGUINTES REGISTROS:
ALUNOS:
(2015010101, JOSE DE ALENCAR, RUA DAS ALMAS, NATAL)
(2015010102, JOÃO JOSÉ, AVENIDA RUY CARNEIRO, JOÃO PESSOA)
(2015010103, MARIA JOAQUINA, RUA CARROSSEL, RECIFE)
(2015010104, MARIA DAS DORES, RUA DAS LADEIRAS, FORTALEZA)
(2015010105, JOSUÉ CLAUDINO DOS SANTOS, CENTRO, NATAL)
(2015010106, JOSUÉLISSON CLAUDINO DOS SANTOS, CENTRO, NATAL)"

insert into alunos values 
(2015010101, 'JOSE DE ALENCAR', 'RUA DAS ALMAS', 'NATAL'),
(2015010102, 'JOÃO JOSÉ', 'AVENIDA RUY CARNEIRO', 'JOÃO PESSOA'),
(2015010103, 'MARIA JOAQUINA', 'RUA CARROSSEL', 'RECIFE'),
(2015010104, 'MARIA DAS DORES', 'RUA DAS LADEIRAS', 'FORTALEZA'),
(2015010105, 'JOSUÉ CLAUDINO DOS SANTOS', 'CENTRO',' NATAL'),
(2015010106, 'JOSUÉLISSON CLAUDINO DOS SANTOS', 'CENTRO', 'NATAL');


"DISCIPLINAS:
(BD, BANCO DE DADOS, 100)
(POO, PROGRAMAÇÃO COM ACESSO A BANCO DE DADOS, 100)
(WEB, AUTORIA WEB, 50)
(ENG, ENGENHARIA DE SOFTWARE, 80)"

insert into disciplinas (cod_disc, tipo, nome_disc, carga_hor)values 
(1, 'BD', 'BANCO DE DADOS', 100),
(2, 'PO', 'PROGRAMAÇÃO COM ACESSO A BANCO DE DADOS', 100),
(3, 'WEB', 'AUTORIA WEB', 50),
(4, 'ENG', 'ENGENHARIA DE SOFTWARE', 80);

"PROFESSORES:
(212131, NICKERSON FERREIRA, RUA MANAÍRA, JOÃO PESSOA)
(122135, ADORILSON BEZERRA, AVENIDA SALGADO FILHO, NATAL)
(192011, DIEGO OLIVEIRA, AVENIDA ROBERTO FREIRE, NATAL)"

insert into professores values
(212131, 'NICKERSON FERREIRA', 'RUA MANAÍRA', 'JOÃO PESSOA'),
(122135, 'ADORILSON BEZERRA', 'AVENIDA SALGADO FILHO', 'NATAL'),
(192011, 'DIEGO OLIVEIRA', 'AVENIDA ROBERTO FREIRE', 'NATAL');

"TURMA:
(1, BD, 1, 212131, 2015, 11H-12H)
(1, BD, 2, 212131, 2015, 13H-14H)
(2, POO, 3, 192011, 2015, 08H-09H)
(3, WEB, 4, 192011, 2015, 07H-08H)
(4, ENG, 5, 122135, 2015, 10H-11H)"

alter table turma 
add column tipo varchar (30);

insert into turma (cod_disc, tipo, cod_turma, cod_prof, ano, horario) values
(1, 'BD', 1, 212131, 2015, '11H-12H'),
(1, 'BD', 2, 212131, 2015, '13H-14H'),
(2, 'POO', 3, 192011, 2015, '08H-09H'),
(3, 'WEB', 4, 192011, 2015, '07H-08H'),
(4, 'ENG', 5, 122135, 2015, '10H-11H');


"Insira valores nos Históricos"

insert into historico (mat, cod_disc, cod_turma, cod_prof, ano, frequencia, nota)values
(2015010101, 1, 1, 212131, 2015, 75, 9.5),
(2015010102, 1, 1, 212131, 2015, 80, 9.8),
(2015010103, 1, 1, 212131, 2015, 80, 9.1),
(2015010104, 2, 2, 212131, 2015, 60, 8.7),
(2015010105, 2, 2, 212131, 2015, 70, 10),
(2015010106, 2, 2, 212131, 2015, 90, 10);

insert into historico (mat, cod_disc, cod_turma, cod_prof, ano, frequencia, nota)values
(2015010101, 3, 3, 122135, 2016, 100, 8.7),
(2015010102, 3, 3, 122135, 2016, 80, 5.9),
(2015010103, 3, 3, 122135, 2016, 100, 9.2),
(2015010104, 4, 4, 122135, 2016, 60, 7.7),
(2015010105, 4, 4, 122135, 2016, 100, 10),
(2015010106, 4, 4, 122135, 2016, 90, 8.7)
(2015010101, 5, 5, 192011, 2017, 100, 8.7),
(2015010102, 5, 5, 192011, 2017, 80, 5.9),
(2015010103, 5, 5, 192011, 2017, 100, 9.2),
(2015010104, 6, 6, 192011, 2017, 60, 7.7),
(2015010105, 6, 6, 192011, 2017, 100, 10),
(2015010106, 6, 6, 192011, 2017, 90, 8.7);

insert into historico (mat, cod_disc, cod_turma, cod_prof, ano, frequencia, nota)values
(2015010101, 2, 1, 212131, 2015, 75, 4.5),
(2015010102, 2, 1, 212131, 2015, 80, 7.8),
(2015010103, 2, 1, 212131, 2015, 80, 7.1),
(2015010104, 2, 2, 212131, 2015, 60, 5.7),
(2015010105, 2, 2, 212131, 2015, 70, 9.0),
(2015010106, 2, 2, 212131, 2015, 90, 10);


"Encontre a MAT dos alunos com nota em BD em 2015 menor que 9.6 
(obs: BD = código da disciplinas)." 

select 
  a.mat , 
  d.tipo, 
  h.ano, 
  h.nota 
from 
  historico h
  inner join disciplinas d
    on d.cod_disc =  h.cod_disc 
  inner join alunos a
    on a.mat = h.mat
 where d.tipo = 'BD' and h.nota < 9.6 and h.ano = 2015; 

"Encontre a MAT e calcule a média das notas dos 
alunos na disciplina de POO em 2015." 

select 
  a.mat ,  
  avg(h.nota) as media
from 
  historico h
  inner join disciplinas d
    on d.cod_disc =  h.cod_disc 
  inner join alunos a
    on a.mat = h.mat
where d.tipo = 'PO' and h.ano = 2015
group by a.mat;

"Encontre a MAT e calcule a média das notas dos alunos na disciplina 
de POO em 2015 e que esta média seja superior a 6."

select 
  a.mat ,  
  avg(h.nota) as media
from 
  historico h
  inner join disciplinas d
    on d.cod_disc =  h.cod_disc 
  inner join alunos a
    on a.mat = h.mat
where d.tipo = 'PO' and h.ano = 2015 and h.nota > 6
group by a.mat;

"Encontre quantos alunos não são de Natal."

select mat, nome, count(nome) as contagem, cidade from alunos
where cidade <> 'NATAL'
group by mat;