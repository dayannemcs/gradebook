using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesanAvgGrade()
        {
            //Arrange
            var book = new Book(""); // Instanciando a classe Book
            book.AddGrade(89.1); //Adicionando notas
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //Act
            var result = book.GetStatistics(); //Buscando o metodo que calcula as estatisticas

            //Assert
            Assert.Equal(85.6, result.Average, 1); //comparando a média esperada com o real e utilizando apenas uma casa decimal
            Assert.Equal(90.5, result.High, 1); //comparando a nota mais alta real com o esperado
            Assert.Equal(77.3, result.Low, 1); // comparando a nota mais baixa com o esperaso
            Assert.Equal('B', result.Letter);
        }
    }
}
