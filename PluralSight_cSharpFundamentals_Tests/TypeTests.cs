﻿using System;
using Xunit;
using PluralSight_cSharpFundamentals; 

namespace PluralSight_cSharpFundamentals_Tests
{
    public class TypeTests
    {

        [Fact]
        public void CanSetNameFromReference() {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name); 
        }
        [Fact]
        public void GetBookReturnDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name); 
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject(){
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2)); 
        }

        Book GetBook(string name) {
            return new Book(name); 
        }

        private void SetName(Book book, string name) {
            book.Name = name; 
        }

        private void GetBookSetName(Book book, string name) {
            book = new Book(name); 
        }
    }
}
