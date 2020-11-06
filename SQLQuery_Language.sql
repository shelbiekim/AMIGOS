CREATE TABLE [dbo].[Language]
(
    [category] NVARCHAR(50) NOT NULL, 
    [language] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY ([language]),
    [weeks] INT NOT NULL, 
    [hours] INT NOT NULL, 
)

INSERT INTO [dbo].[Language]
VALUES 
('Category 1','Danish', 24, 600),
('Category 1','Dutch', 24, 600),
('Category 1','French', 30, 750),
('Category 1','Italian', 24, 600),
('Category 1','Norwegian', 24, 600),
('Category 1','Portuguese', 24, 600),
('Category 1','Romanian', 24, 600),
('Category 1','Spanish', 24, 600),
('Category 1','Swedish', 24, 600),
('Category 2','German', 36, 900),
('Category 2','Haitian Creole', 36, 900),
('Category 2','Indonesian', 36, 900),
('Category 2','Malay', 36, 900),
('Category 2','Swahili', 36, 900),
('Category 3','Finnish', 44, 1100),
('Category 3','Greek', 44, 1100),
('Category 3','Hebrew', 44, 1100),
('Category 3','Hindi', 44, 1100),
('Category 3','Hungarian', 44, 1100),
('Category 3','Icelandic', 44, 1100),
('Category 3','Macedonian', 44, 1100),
('Category 3','Mongolian', 44, 1100),
('Category 3','Polish', 44, 1100),
('Category 3','Russian', 44, 1100),
('Category 3','Thai', 44, 1100),
('Category 4','Arabic', 88, 2200),
('Category 4','Chinese - Cantonese', 88, 2200),
('Category 4','Chinese - Mandarin', 88, 2200),
('Category 4','Japanese', 88, 2200),
('Category 4','Korean', 88, 2200)


