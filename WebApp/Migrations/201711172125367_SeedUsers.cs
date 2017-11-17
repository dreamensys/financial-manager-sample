namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                -- USers
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'51bc3142-95c0-465a-9565-3bc5753e9b22', N'superintendent@test.com', 0, N'AFQLpCeioyw4+zRnjgOoulLwM9Wl0m5Nibbg4huxWbEG3b6ZSId3FY2Tcq7lbrofFQ==', N'7e99059e-ea85-435d-b105-9563fd4ccad1', NULL, 0, 0, NULL, 1, 0, N'superintendent@test.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'73c887a9-65a4-4020-b471-911ee8cde023', N'manager@test.com', 0, N'APYVWaah1uFG+lmdR4fMdmjKGd3ncs0AiAB29HqZouKxvWojroyarAlZhwTf5k1/7w==', N'0207a57b-d33f-4c16-b9b3-a57733833549', NULL, 0, 0, NULL, 1, 0, N'manager@test.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'98a31ac0-9a50-4c62-b4ad-a8b2e2a2b761', N'assistant@test.com', 0, N'AE8MARy3+A4H//BUPMlEwexjrgG0DoOS54aZ6zxfoYJfKTKIfOoCMa6kfSxcmA2Nmw==', N'28ff24b9-4cbb-4d9e-a9b1-9f44dec03d83', NULL, 0, 0, NULL, 1, 0, N'assistant@test.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e0013c50-eb66-40b7-b4a8-dab08a1cbb33', N'administrator@test.com', 0, N'ABeyS8w3i5GnmTex0UDAFOgUdijvCuJtRacbZgYAxJ/sJXUVIaQhnvDLMSeZ+cRycQ==', N'325bd238-c344-41d3-9974-933855c335a5', NULL, 0, 0, NULL, 1, 0, N'administrator@test.com')

                -- ROles
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'37e44a44-15f1-4b65-96d9-82d62c61ae32', N'Administrator')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1434f452-87c6-4e19-bb6f-17c39ece1375', N'Assistant')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'18ec6402-4d67-43c8-a8a1-6df687a11c7f', N'Manager')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'344b5045-fe0d-4de6-86dc-63127d1527df', N'Superintendent')

                --ROlesByUSer
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'98a31ac0-9a50-4c62-b4ad-a8b2e2a2b761', N'1434f452-87c6-4e19-bb6f-17c39ece1375')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'73c887a9-65a4-4020-b471-911ee8cde023', N'18ec6402-4d67-43c8-a8a1-6df687a11c7f')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'51bc3142-95c0-465a-9565-3bc5753e9b22', N'344b5045-fe0d-4de6-86dc-63127d1527df')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e0013c50-eb66-40b7-b4a8-dab08a1cbb33', N'37e44a44-15f1-4b65-96d9-82d62c61ae32')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
