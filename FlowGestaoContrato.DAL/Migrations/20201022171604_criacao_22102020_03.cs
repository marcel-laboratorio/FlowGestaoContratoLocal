using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowGestaoContrato.DAL.Migrations
{
    public partial class criacao_22102020_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "68215191-f773-4d20-9932-b5d818f00984");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "d9307705-4e52-4827-af7b-01b151e2994f");

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "21c50826-dff9-43eb-a00e-fcc6b3f63390", "67dea951-fe59-4c59-83d7-21ba96362790", "Gestor do Flow", "Gestor", "GESTOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "db5dfd85-47cb-48be-8e57-bb5cec8d6fa7", "2130e349-a0f2-4498-9d8b-ce17df724d30", "Fornecedor Eneva", "Fornecedor", "FORNECEDOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "54416365-9473-4c35-9b8a-0a14cc9d43aa", "ddbc2621-df68-4b70-a65a-d7c2f840d568", "Administrador do Flow", "Administrador", "ADMINISTRADOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "21c50826-dff9-43eb-a00e-fcc6b3f63390");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "54416365-9473-4c35-9b8a-0a14cc9d43aa");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "db5dfd85-47cb-48be-8e57-bb5cec8d6fa7");

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "d9307705-4e52-4827-af7b-01b151e2994f", "c0f59924-1771-49ef-bb3b-a514f8b9a1fd", "Fornecedor Eneva", "Fornecedor", "FORNECEDOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "68215191-f773-4d20-9932-b5d818f00984", "cb354777-2735-4340-aa61-b2f7edf6b88b", "Administrador do Flow", "Administrador", "ADMINISTRADOR" });
        }
    }
}
