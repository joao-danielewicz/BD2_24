use campeonato;

insert into [equipe] ([nome_equipe], [id_torneio]) values
('China', 3),
('França', 3),
('Brasil', 3),
('Taipé Chinesa', 3),
('Japão', 3),
('Alemanha', 3),
('Coreia do Sul', 3),
('Portugal', 3),
('Eslovênia', 3),
('Nigéria', 3),
('Egito', 3),
('Dinamarca', 3),
('Espanha', 3),
('Canadá', 3),
('Austrália', 3),
('Índia', 3),
('Grã-Bretanha', 3),
('Romênia', 3),
('Cazaquistão', 3),
('Hong Kong', 3),
('Irã', 3),
('Croácia', 3),
('Cuba', 3),
('Chile', 3),
('Áustria', 3),
('Eslováquia', 3),
('Porto Rico', 3),
('Equador', 3),
('Bélgica', 3),
('Argentina', 3),
('México', 3),
('Singapura', 3),
('Senegal', 3),
('Luxemburgo', 3),
('Grécia', 3),
('Algéria', 3),
('Estados Unidos', 3),
('Madagascar', 3),
('Ucrânia', 3),
('Fiji', 3),
('Moldávia', 3),
('Jordânia', 3),
('Nepal', 3),
('Suécia', 3);

insert into [atleta] ([nome], [id_equipe]) values
1.   'Wang Chuqin' (CHN) (second round)
2.   'Fan Zhendong' (CHN) (champion, gold medalist)
3.   'Félix Lebrun' (FRA) (semifinals, bronze medalist)
4.   'Hugo Calderano' (BRA) (semifinals, fourth place)
5.   'Lin Yun-ju' (TPE) (quarterfinals)
6.   'Tomokazu Harimoto' (JPN) (quarterfinals)
7.   'Dang Qiu' (GER) (second round)
8.   'Jang Woo-jin' (KOR) (quarterfinals)
9.   'Dimitrij Ovtcharov' (GER) (round of 16)
10.   'Shunsuke Togami' (JPN) (round of 16)
11.   'Alexis Lebrun' (FRA) (round of 16)
12.   'Marcos Freitas' (POR) (first round)
13.   'Darko Jorgic' (SLO) (round of 16)
14.   'Quadri Aruna' (NGR) (first round)
15.   'Cho Dae-seong' (KOR) (first round)
16.   'Omar Assar' (EGY) (quarterfinals)
17.   'Jonathan Groth' (DEN) (second round)
18.   'Anton Källberg' (SWE) (second round)
19.   'Truls Moregardh' (SWE) (final, silver medalist)
20.   'Kao Cheng-jui' (TPE) (round of 16)
21.   'Álvaro Robles' (ESP) (second round)
22.   'Edward Ly' (CAN) (first round)
23.   'Nicholas Lum' (AUS) (first round)
24.   'Sharath Kamal' Achanta (IND) (first round)
25.   'Liam Pitchford' (GBR) (second round)
26.   'Finn Luu' (AUS) (first round)
27.   'Ovidiu Ionescu' (ROU) (first round)
28.   'Kirill Gerassimenko' (KAZ) (round of 16)
29.   'Mohamed El-Beiali' (EGY) (first round)
30.   'Wong Chun Ting' (HKG) (second round)
31.   'Noshad Alamian' (IRI) (second round)
32.   'Tomislav Pucar' (CRO) (second round)
33.   'Andy Pereira' (CUB) (first round)
34.   'Nicolás Burgos' (CHI) (first round)
35.   'Anders Lind' (DEN) (round of 16)
36.   'Daniel Habesohn' (AUT) (first round)
37.   'Tiago Apolónia' (POR) (first round)
38.   'Andrej Gaćina' (CRO) (second round)
39.   'Wang Yang' (SVK) (first round)
40.   'Eduard Ionescu' (ROU) (second round)
41.   'Miłosz Redzimski' (POL) (second round)
42.   'Brian Afanador' (PUR) (first round)
43.   'Alberto Miño' (ECU) (second round)
44.   'Martin Allegro' (BEL) (first round)
45.   'Santiago Lorenzo' (ARG) (first round)
46.   'Marcos Madrid' (MEX) (first round)
47.   'Izaac Quek' (SGP) (first round)
48.   'Vitor Ishiy' (BRA) (second round)
49.   'Harmeet Desai' (IND) (first round)
50.   'Daniel González' (PUR) (first round)
51.   'Ibrahima Diaw' (SEN) (first round)
52.   'Luka Mladenovic' (LUX) (first round)
53.   'Cedric Nuytinck' (BEL) (first round)
54.   'Olajide Omotayo' (NGR) (first round)
55.   'Eugene Wang' (CAN) (first round)
56.   'Panagiotis Gionis' (GRE) (second round)
57.   'Mehdi Bouloussa' (ALG) (first round)
58.   'Saheed Idowu' (CGO) (first round)
59.   'Kanak Jha' (USA) (round of 16)
60.   'Deni Kožul' (SLO) (second round)
61.   'Fabio Rakotoarimanana' (MAD) (first round)
62.   'Yaroslav Zhmudenko' (UKR) (first round)
63.   'Nima Alamian' (IRI) (first round)
64.   'Vicky Wu' (FIJ) (first round)




select * from equipe;

insert into equipe(nome_equipe, id_torneio) values ('Polônia', 3);
insert into [atleta] ([nome], [id_equipe]) values
('Wang Chuqin', 13),
('Fan Zhendong', 13),
('Félix Lebrun', 14),
('Hugo Calderano', 15),
('Lin Yun-ju', 16),
('Tomokazu Harimoto', 17),
('Dang Qiu', 18),
('Jang Woo-jin', 19),
('Dimitrij Ovtcharov', 18),
('Shunsuke Togami', 17),
('Alexis Lebrun', 14),
('Marcos Freitas', 20),
('Darko Jorgic', 21),
('Quadri Aruna', 22),
('Cho Dae-seong', 19),
('Omar Assar', 23),
('Jonathan Groth', 24),
('Anton Källberg', 56),
('Truls Moregardh', 56),
('Kao Cheng-jui', 16),
('Álvaro Robles', 25),
('Edward Ly', 26),
('Nicholas Lum', 27),
('Sharath Kamal Achanta', 28),
('Liam Pitchford', 29),
('Finn Luu', 27),
('Ovidiu Ionescu', 30),
('Kirill Gerassimenko', 31),
('Mohamed El-Beiali', 23),
('Wong Chun Ting', 32),
('Noshad Alamian', 33),
('Tomislav Pucar', 34),
('Andy Pereira', 35),
('Nicolás Burgos', 36),
('Anders Lind', 24),
('Daniel Habesohn', 37),
('Tiago Apolónia', 20),
('Andrej Gaćina', 34),
('Wang Yang', 38),
('Eduard Ionescu', 30),
('Miłosz Redzimski', 59),
('Brian Afanador', 39),
('Alberto Miño', 40),
('Martin Allegro', 41),
('Santiago Lorenzo', 42),
('Marcos Madrid', 43),
('Izaac Quek', 44),
('Vitor Ishiy', 15),
('Harmeet Desai', 57),
('Daniel González', 39),
('Ibrahima Diaw', 45),
('Luka Mladenovic', 46),
('Cedric Nuytinck', 41),
('Olajide Omotayo', 22),
('Eugene Wang', 26),
('Panagiotis Gionis', 47),
('Mehdi Bouloussa', 48) ,
('Saheed Idowu', 58),
('Kanak Jha', 49),
('Deni Kožul', 21),
('Fabio Rakotoarimanana', 53) ,
('Yaroslav Zhmudenko', 51) ,
('Nima Alamian', 33),
('Vicky Wu', 52);

select a.nome, e.nome_equipe from atleta as a inner join equipe as e on e.id_equipe = a.id_equipe;