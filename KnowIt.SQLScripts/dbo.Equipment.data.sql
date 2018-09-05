SET IDENTITY_INSERT [dbo].[Equipment] ON
INSERT INTO [dbo].[Equipment] ([EquipmentID], [OwnerID], [EquipmentName], [EquipmentNote]) VALUES (1, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'MPA', N'Coronary Diagnostic Catheter for hard to reach places')
INSERT INTO [dbo].[Equipment] ([EquipmentID], [OwnerID], [EquipmentName], [EquipmentNote]) VALUES (2, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'FL 3.5', N'Left Coronary Diagnostic Catheter')
INSERT INTO [dbo].[Equipment] ([EquipmentID], [OwnerID], [EquipmentName], [EquipmentNote]) VALUES (3, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'7.5 fr Swan Ganz Catheter', N'Diagnostic Catheter able to complete Fick and Thermal Cardiac Outputs')
INSERT INTO [dbo].[Equipment] ([EquipmentID], [OwnerID], [EquipmentName], [EquipmentNote]) VALUES (4, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'FR 5', N'Right Coronary Diagnostic Catheter')
INSERT INTO [dbo].[Equipment] ([EquipmentID], [OwnerID], [EquipmentName], [EquipmentNote]) VALUES (5, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Temporary Pacemaker Lead Flow Directed', N'Need Temporary Pacemaker Console')
INSERT INTO [dbo].[Equipment] ([EquipmentID], [OwnerID], [EquipmentName], [EquipmentNote]) VALUES (6, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'FL 3', N'Left Coronary Diagnostic Catheter')
INSERT INTO [dbo].[Equipment] ([EquipmentID], [OwnerID], [EquipmentName], [EquipmentNote]) VALUES (7, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Computer', N'Apple, Dell, HP, etc ')
INSERT INTO [dbo].[Equipment] ([EquipmentID], [OwnerID], [EquipmentName], [EquipmentNote]) VALUES (8, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'XB 3.5', N'Left Coronary Guide Catheter')
INSERT INTO [dbo].[Equipment] ([EquipmentID], [OwnerID], [EquipmentName], [EquipmentNote]) VALUES (9, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'XBLAD 3.5', N'Left Coronary Guide Catheter')
INSERT INTO [dbo].[Equipment] ([EquipmentID], [OwnerID], [EquipmentName], [EquipmentNote]) VALUES (10, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'JR 5', N'Right Coronary Guide Catheter')
SET IDENTITY_INSERT [dbo].[Equipment] OFF

SET IDENTITY_INSERT [dbo].[Medication] ON
INSERT INTO [dbo].[Medication] ([MedicationID], [OwnerID], [MedicationName], [MedicationClass], [MedicationUse], [Assigned], [PhysicianPreference_PhysicianPreferenceID]) VALUES (1, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Versed', N'Benzodiazepine', N'Sedation', 0, NULL)
INSERT INTO [dbo].[Medication] ([MedicationID], [OwnerID], [MedicationName], [MedicationClass], [MedicationUse], [Assigned], [PhysicianPreference_PhysicianPreferenceID]) VALUES (2, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Benadryl', N'Antihistamine', N'Sedation adjunct', 0, NULL)
INSERT INTO [dbo].[Medication] ([MedicationID], [OwnerID], [MedicationName], [MedicationClass], [MedicationUse], [Assigned], [PhysicianPreference_PhysicianPreferenceID]) VALUES (3, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Fentanyl', N'Synthetic Narcotic', N'Pain/Sedation', 0, NULL)
INSERT INTO [dbo].[Medication] ([MedicationID], [OwnerID], [MedicationName], [MedicationClass], [MedicationUse], [Assigned], [PhysicianPreference_PhysicianPreferenceID]) VALUES (4, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Morphine', N'Narcotic', N'Pain', 0, NULL)
INSERT INTO [dbo].[Medication] ([MedicationID], [OwnerID], [MedicationName], [MedicationClass], [MedicationUse], [Assigned], [PhysicianPreference_PhysicianPreferenceID]) VALUES (5, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Caffeine', N'Stimulant', N'Help Debugger Focus', 0, NULL)
INSERT INTO [dbo].[Medication] ([MedicationID], [OwnerID], [MedicationName], [MedicationClass], [MedicationUse], [Assigned], [PhysicianPreference_PhysicianPreferenceID]) VALUES (6, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Dilaudid', N'Narcotic', N'Pain', 0, NULL)
INSERT INTO [dbo].[Medication] ([MedicationID], [OwnerID], [MedicationName], [MedicationClass], [MedicationUse], [Assigned], [PhysicianPreference_PhysicianPreferenceID]) VALUES (7, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Keflex', N'Cephalosporin', N'Antibiotic', 0, NULL)
INSERT INTO [dbo].[Medication] ([MedicationID], [OwnerID], [MedicationName], [MedicationClass], [MedicationUse], [Assigned], [PhysicianPreference_PhysicianPreferenceID]) VALUES (8, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Lidocaine', N'Sodium Channel Blocker', N'Local Anesthetic', 0, NULL)
INSERT INTO [dbo].[Medication] ([MedicationID], [OwnerID], [MedicationName], [MedicationClass], [MedicationUse], [Assigned], [PhysicianPreference_PhysicianPreferenceID]) VALUES (9, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Epinephrine', N'Adrenergics', N'Vasopressor', 0, NULL)
INSERT INTO [dbo].[Medication] ([MedicationID], [OwnerID], [MedicationName], [MedicationClass], [MedicationUse], [Assigned], [PhysicianPreference_PhysicianPreferenceID]) VALUES (10, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Atropine', N'Anticholenergic', N'Speed it up', 0, NULL)
SET IDENTITY_INSERT [dbo].[Medication] OFF

SET IDENTITY_INSERT [dbo].[Physician] ON
INSERT INTO [dbo].[Physician] ([PhysicianID], [OwnerID], [PhysicianFirstName], [PhysicianLastName], [Specialty]) VALUES (1, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Paul', N'O''Connor', N'Debugging')
INSERT INTO [dbo].[Physician] ([PhysicianID], [OwnerID], [PhysicianFirstName], [PhysicianLastName], [Specialty]) VALUES (2, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Kenn', N'Pascascio', N'Debugging')
INSERT INTO [dbo].[Physician] ([PhysicianID], [OwnerID], [PhysicianFirstName], [PhysicianLastName], [Specialty]) VALUES (3, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Alex', N'Moritz', N'Debugging')
INSERT INTO [dbo].[Physician] ([PhysicianID], [OwnerID], [PhysicianFirstName], [PhysicianLastName], [Specialty]) VALUES (4, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Doug', N'Pitts', N'Cardiology - Heart Failure Specialist')
INSERT INTO [dbo].[Physician] ([PhysicianID], [OwnerID], [PhysicianFirstName], [PhysicianLastName], [Specialty]) VALUES (5, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Sampson', N'Andrew', N'Cardiology - Interventional/Structural')
INSERT INTO [dbo].[Physician] ([PhysicianID], [OwnerID], [PhysicianFirstName], [PhysicianLastName], [Specialty]) VALUES (6, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Hodes', N'Zachary', N'Cardiology - Interventional Cardiology')
INSERT INTO [dbo].[Physician] ([PhysicianID], [OwnerID], [PhysicianFirstName], [PhysicianLastName], [Specialty]) VALUES (7, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Rafael', N'Garcia-Cortes', N'Cardiology - Heart Failure Specialist')
INSERT INTO [dbo].[Physician] ([PhysicianID], [OwnerID], [PhysicianFirstName], [PhysicianLastName], [Specialty]) VALUES (8, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Ashwin', N'Ravichandran', N'Cardiology - Heart Failure Specialist')
INSERT INTO [dbo].[Physician] ([PhysicianID], [OwnerID], [PhysicianFirstName], [PhysicianLastName], [Specialty]) VALUES (9, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Charles', N'Orr', N'Cardiology - Interventionalist')
INSERT INTO [dbo].[Physician] ([PhysicianID], [OwnerID], [PhysicianFirstName], [PhysicianLastName], [Specialty]) VALUES (10, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Adam', N'Werne', N'Cardiology - Interventionalist')
SET IDENTITY_INSERT [dbo].[Physician] OFF

SET IDENTITY_INSERT [dbo].[Procedure] ON
INSERT INTO [dbo].[Procedure] ([ProcedureID], [OwnerID], [ProcedureName], [ProcedureNote], [ProcedureRoute]) VALUES (1, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Left Cardiac Catheterization', N'Diagnositic procedure, coronary angio and cross the aortic valve to measure LV pressures.', N'Femoral/Radial')
INSERT INTO [dbo].[Procedure] ([ProcedureID], [OwnerID], [ProcedureName], [ProcedureNote], [ProcedureRoute]) VALUES (2, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Right Cardiac Catheterization', N'Measure Venous Pressures of the heart', N'Internal Jugular/Femoral')
INSERT INTO [dbo].[Procedure] ([ProcedureID], [OwnerID], [ProcedureName], [ProcedureNote], [ProcedureRoute]) VALUES (3, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Atrial Septal Defect Closure', N'It''s Hermiller', N'Femoral')
INSERT INTO [dbo].[Procedure] ([ProcedureID], [OwnerID], [ProcedureName], [ProcedureNote], [ProcedureRoute]) VALUES (4, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Temporary Pacemaker Insertion', N'Femoral/Internal Jugular', N'Due to bradycardia usually')
INSERT INTO [dbo].[Procedure] ([ProcedureID], [OwnerID], [ProcedureName], [ProcedureNote], [ProcedureRoute]) VALUES (5, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Debug', N'Take debugging issues to bistro to hear bistro squeeking and help concentration', N'Computer Interface')
INSERT INTO [dbo].[Procedure] ([ProcedureID], [OwnerID], [ProcedureName], [ProcedureNote], [ProcedureRoute]) VALUES (6, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Ventricular Septal Defect Closure', N'It''s Hermiller', N'Femoral')
INSERT INTO [dbo].[Procedure] ([ProcedureID], [OwnerID], [ProcedureName], [ProcedureNote], [ProcedureRoute]) VALUES (7, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Balloon Angioplasty', N'Not done very often as a standalone therapy', N'Radial/Femoral')
INSERT INTO [dbo].[Procedure] ([ProcedureID], [OwnerID], [ProcedureName], [ProcedureNote], [ProcedureRoute]) VALUES (8, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Laser Athrectomy', N'May be a long case', N'Femoral sometimes radially')
INSERT INTO [dbo].[Procedure] ([ProcedureID], [OwnerID], [ProcedureName], [ProcedureNote], [ProcedureRoute]) VALUES (9, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Rotational Athrectomy', N'Diamondback', N'Femoral')
INSERT INTO [dbo].[Procedure] ([ProcedureID], [OwnerID], [ProcedureName], [ProcedureNote], [ProcedureRoute]) VALUES (10, N'6040d91b-fd01-40c5-bcb6-37d18d6fbbf3', N'Cardiomems Implant', N'Longer Right Heart Cath attempt to implant in Left PA', N'Femoral but attempting IJ')
SET IDENTITY_INSERT [dbo].[Procedure] OFF
