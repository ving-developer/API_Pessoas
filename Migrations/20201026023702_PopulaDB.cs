using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Pessoas.Migrations
{
    public partial class PopulaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into pessoas(nome, cpf,dt_nascimento,email,senha) values('Henrique Barros',05302278006, '1999-09-25','henrique.sb0709@gmail.com','mysql')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from pessoas");
        }
    }
}
