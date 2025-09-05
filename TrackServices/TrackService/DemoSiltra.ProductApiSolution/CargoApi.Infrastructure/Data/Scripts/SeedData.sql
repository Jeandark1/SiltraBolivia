-- Insertar datos iniciales
INSERT INTO [DataUsers] ([ExternalUserId], [Name], [FSurname], [MSurname], [Email], [Phone], [Address], [Status], [CreatedAt])
VALUES 
('auth0|123456789', 'Admin', 'System', 'User', 'admin@siltra.com', '59178946206', 'La Paz, Bolivia', 1, GETDATE());

-- Insertar roles del sistema
INSERT INTO [Roles] ([Name], [Description], [IsActive])
VALUES 
('Admin', 'Administrador del sistema', 1),
('Client', 'Cliente regular', 1),
('Company', 'Empresa cliente', 1),
('Driver', 'Conductor/Transportista', 1);