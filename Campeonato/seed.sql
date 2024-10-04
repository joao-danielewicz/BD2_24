-- Inserindo dados na tabela MODALIDADE
INSERT INTO MODALIDADE (NOME, TIPO_MODALIDADE) VALUES 
('Futebol', 'Equipe'),
('Natação', 'Individual'),
('Basquete', 'Equipe'),
('Atletismo', 'Individual'),
('Vôlei', 'Equipe'),
('Ciclismo', 'Individual');

-- Inserindo dados na tabela GRUPO
INSERT INTO GRUPO (NOME, TIPO_GRUPO) VALUES 
('Grupo A', 'Chaveamento'),
('Grupo B', 'Chaveamento'),
('Grupo C', 'Pontos corridos'),
('Grupo D', 'Chaveamento'),
('Grupo E', 'Chaveamento'),
('Grupo Geral', 'Pontos corridos');  -- Grupo para atletas individuais

-- Inserindo dados na tabela EQUIPE
INSERT INTO EQUIPE (NOME, ID_MODALIDADE, ID_GRUPO) VALUES 
('Time do Brasil', 1, 1),
('Time da Argentina', 1, 1),
('Time da Alemanha', 1, 1),
('Time dos EUA', 3, 2),
('Time da Espanha', 1, 2),
('Time da França', 1, 2),
('Time de Natação 1', 2, 6),  -- Natação no Grupo Geral
('Time de Natação 2', 2, 6),  -- Natação no Grupo Geral
('Time de Basquete A', 3, 4),
('Time de Basquete B', 3, 4),
('Time de Vôlei A', 5, 5),
('Time de Vôlei B', 5, 5),
('Time de Ciclismo A', 6, 6),  -- Ciclismo no Grupo Geral
('Time de Ciclismo B', 6, 6),
('Equipe Geral Atletismo', 4, 6),  -- Equipe Geral para atletas individuais
('Equipe Geral Ciclismo', 6, 6),
('Equipe Geral Natação', 2, 6);

-- Inserindo dados na tabela ATLETA
INSERT INTO ATLETA (NOME, DATA_NASC, ID_EQUIPE) VALUES 
('Pelé', '1940-10-23', 1),            -- Pelé no Time do Brasil
('Messi', '1987-06-24', 2),            -- Messi no Time da Argentina
('Cristiano Ronaldo', '1985-02-05', 3), -- Cristiano Ronaldo no Time da Alemanha
('Michael Phelps', '1985-06-30', 7),   -- Michael Phelps na Natação
('Usain Bolt', '1986-08-21', 14),      -- Usain Bolt na Equipe Geral (Atletismo)
('Kobe Bryant', '1978-08-23', 8),      -- Kobe Bryant no Time de Basquete A
('LeBron James', '1984-12-30', 10);    -- LeBron James no Time de Basquete B

-- Inserindo dados na tabela PARTICIPACAO
INSERT INTO PARTICIPACAO (ID_ATLETA, ID_EQUIPE, ID_GRUPO, ID_MODALIDADE) VALUES 
(1, 1, 1, 1),  -- Pelé no Time do Brasil (Futebol)
(2, 2, 1, 1),  -- Messi no Time da Argentina (Futebol)
(3, 3, 1, 1),  -- Cristiano Ronaldo na Time da Alemanha (Futebol)
(4, 7, 6, 2),  -- Michael Phelps na Natação (Individual)
(5, 14, 6, 4),  -- Usain Bolt na Equipe Geral (Atletismo)
(6, 9, 4, 3),  -- Kobe Bryant na Time de Basquete A
(7, 10, 4, 3);  -- LeBron James na Time de Basquete B

-- Inserindo dados na tabela PARTIDA
INSERT INTO PARTIDA (FASE, QTD_PONTOS, ID_PARTICIPACAO_VENCEDORA) VALUES 
('Classificatória', 3, 1),  -- Vitória de Pelé
('Classificatória', 3, 2),  -- Vitória de Messi
('Classificatória', 3, 3),  -- Vitória de Cristiano Ronaldo
('Oitava', 3, 4),  -- Vitória de Michael Phelps
('Quarta', 3, 6),  -- Vitória de Kobe Bryant
('Quarta', 3, 7),  -- Vitória de LeBron James
('Semifinal', 3, 1),  -- Vitória de Pelé novamente
('Semifinal', 3, 2),  -- Vitória de Messi novamente
('Final', 3, 3),  -- Vitória de Cristiano Ronaldo na final do futebol
('Final', 3, 4);  -- Vitória de Michael Phelps na final de natação