using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowGestaoContrato.DAL.Migrations
{
    public partial class criacao_22102020_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "3756e085-e0d0-4380-8be2-baf09ff0451b");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "955e0b1c-a593-4861-b7cd-1c4e40f9fb7c");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "f5b821ff-97ac-4b65-a0ea-0d3fe46aadb2");

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "d9307705-4e52-4827-af7b-01b151e2994f", "c0f59924-1771-49ef-bb3b-a514f8b9a1fd", "Fornecedor Eneva", "Fornecedor", "FORNECEDOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "68215191-f773-4d20-9932-b5d818f00984", "cb354777-2735-4340-aa61-b2f7edf6b88b", "Administrador do Flow", "Administrador", "ADMINISTRADOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f5b821ff-97ac-4b65-a0ea-0d3fe46aadb2", "f515ad93-1071-483d-9e7c-34f9aee4e208", "Gestor do Flow", "Gestor", "GESTOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "3756e085-e0d0-4380-8be2-baf09ff0451b", "50282074-137a-4043-b291-dc89f87c9482", "Fornecedor Eneva", "Fornecedor", "FORNECEDOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "955e0b1c-a593-4861-b7cd-1c4e40f9fb7c", "36f461b4-551b-41e8-954e-3fec181e59f0", "Administrador do Flow", "Administrador", "ADMINISTRADOR" });
        }
    }
}
