using System;
using Xunit;
using IIG.BinaryFlag;

namespace BinaryFlag.Tests
{
    public class UnitTest1
    {
        ulong default_length = 32;
        //Потік виконання 
        [Theory]
        [InlineData(2)]
        // [InlineData(17179868704)]
        [InlineData(0xFFF)]
        [InlineData(2)]
        public void isFlagTrueWhenConstructorWithOnlyLength(ulong length)
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(length);
            Assert.True(flag.GetFlag());
            // Assert.True(flag.GetType() == typeof(MultipleBinaryFlag));
        }

         [Theory]
        [InlineData(2)]
        // [InlineData(17179868704)]
        [InlineData(0xFFF)]
        [InlineData(2)]
        public void isFlagFalseWithDiffLengthsAndInitValueFalse(ulong length){
             MultipleBinaryFlag flag = new MultipleBinaryFlag(length, false);
             Assert.False(flag.GetFlag());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public void doesThrowExcWhenLengthLessThan2(int length){
            try{
                MultipleBinaryFlag flag = new MultipleBinaryFlag((ulong)length);
                Assert.False(true); //if doesnt throw exception then test method failed
            }catch(ArgumentOutOfRangeException exc){
                string errMessage = "Length of Flag must be bigger than one";
                Assert.True(exc.Message.Contains(errMessage));
            }
        }

        [Fact]
        public void doesThrowExcWhenLengthMoreThanMax(){
            // ulong length = 17179868705;
            try{
                MultipleBinaryFlag flag = new MultipleBinaryFlag(17179868705);
                Assert.False(true); //if doesnt throw exception then test method failed
            }catch(ArgumentOutOfRangeException exc){
                string errMessage = "Length of Flag must be lesser than '17179868705'";
                Assert.True(exc.Message.Contains(errMessage));
            }
        }

        [Fact]
        public void 

         [Fact]
        public void doesSetFlagWorksCorrect()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(default_length, false);
            for (ulong i = 0; i < default_length; i++) {
                flag.SetFlag(i);
            }
            Assert.True(flag.GetFlag());
        }
        [Fact]
        public void doesResetFlagWorksCorrect()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(default_length);
            for (ulong i = 0; i < default_length; i++) {
                flag.ResetFlag(i);
            }
            Assert.False(flag.GetFlag());
        }
        // [Fact]
        // public void checkIfUIntInstanceCreated(){
        //     ulong length = 16;

        //     MultipleBinaryFlag flag = new MultipleBinaryFlag(length);

        //     for (int position = 0; position < length; position++){   
        //         try{
        //             flag.SetFlag(position);
        //         }
        //     }
        // }
        //Тестування 
    }
}
