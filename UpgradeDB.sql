
--************************03/10/2023************************--

--*******************Caracteristique****************--
	ALTER TABLE Caracteristique Add HasDescription bit;
	EXEC sp_rename 'Caracteristique.HasCamera', 'HasPosition', 'COLUMN';

--*******************Article**********************--
ALTER TABLE Article DROP COLUMN Camera;
ALTER TABLE Article Add [Description] NVARCHAR (Max) NULL;

--********************* End ******************************--