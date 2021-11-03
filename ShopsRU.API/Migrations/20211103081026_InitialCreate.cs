using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopsRU.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Percent = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CustomersId = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_UserType",
                table: "Discounts",
                column: "UserType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomersId",
                table: "Invoices",
                column: "CustomersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");
        }

        #region SQL Queries

        #region Customer Query

        /* USE [SHOPRU-DB]
		   GO

			SET ANSI_NULLS ON
			GO

		   SET QUOTED_IDENTIFIER ON
		   GO

		   CREATE TABLE[dbo].[Customers]
				   (

			  [Id][int] IDENTITY(1,1) NOT NULL,

			 [Name] [nvarchar] (40) NULL,
			   [Address] [nvarchar] (150) NULL,
			   [UserType] [int] NOT NULL,

			   [ModifiedAt] [datetime2] (7) NULL,
			   [CreatedAt] [datetime2] (7) NULL,
			CONSTRAINT[PK_Customers] PRIMARY KEY CLUSTERED
		   (
			  [Id] ASC
		   )WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
		   ) ON[PRIMARY]
		   GO

	   */

        #endregion Customer Query

        #region Discounts Query

        /*
			USE [SHOPRU-DB]
			GO

			SET ANSI_NULLS ON
			GO

			SET QUOTED_IDENTIFIER ON
			GO

			CREATE TABLE [dbo].[Discounts](
				[Id] [int] IDENTITY(1,1) NOT NULL,
				[Name] [nvarchar](10) NULL,
				[Percent] [int] NOT NULL,
				[UserType] [int] NOT NULL,
				[ModifiedAt] [datetime2](7) NULL,
				[CreatedAt] [datetime2](7) NULL,
			 CONSTRAINT [PK_Discounts] PRIMARY KEY CLUSTERED
			(
				[Id] ASC
			)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
			) ON [PRIMARY]
			GO
		*/

        #endregion Discounts Query

        #region Invoices Query

        /*
		 USE [SHOPRU-DB]
		GO

		SET ANSI_NULLS ON
		GO

		SET QUOTED_IDENTIFIER ON
		GO

		CREATE TABLE [dbo].[Invoices](
			[Id] [int] IDENTITY(1,1) NOT NULL,
			[InvoiceNumber] [nvarchar](20) NULL,
			[TotalAmount] [decimal](18, 4) NOT NULL,
			[DiscountAmount] [decimal](18, 4) NOT NULL,
			[CustomersId] [int] NULL,
			[ModifiedAt] [datetime2](7) NULL,
			[CreatedAt] [datetime2](7) NULL,
		 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED
		(
			[Id] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		GO

		ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Customers_CustomersId] FOREIGN KEY([CustomersId])
		REFERENCES [dbo].[Customers] ([Id])
		GO

		ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Customers_CustomersId]
		GO
		 */

        #endregion Invoices Query

        #endregion SQL Queries
    }
}