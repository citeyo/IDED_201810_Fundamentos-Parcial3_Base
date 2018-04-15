using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcial3_Base;

namespace Parcial3.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        private Program testProgram = new Program();

        // NO Modifique esta sección. Son las variables para los casos de prueba. Puede copiarlas
        // en su código para verificar que todo funcione con los casos de prueba esperados.

        #region TEST_VARS

        private const float DELTA_ACC = 0.001F;
        private const string TIME_FORMAT = "{0} hrs : {1} mins : {2} segs";

        #region MATRICES

        private int[,] testMatrixA = new int[3, 3];
        private int[,] testMatrixB = new int[3, 4];
        private int[,] testMatrixC = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
        private int[,] testMatrixD = { { 4, 6, 7 }, { 10, 89, 500 }, { 100, 450, 600 } };
        private int[,] testMatrixE = { { 45, 67 }, { 67, 98 } };
        private int[,] testMatrixF = { { 12 }, { 75 } };

        private int[,] testMatrixResultA = null; //AXF
        private int[,] testMatrixResultB = { { 4, 6, 7 }, { 10, 89, 500 }, { 100, 450, 600 } }; //CXD
        private int[,] testMatrixResultC = { { 5565 }, { 8154 } }; //EXF
        private int[,] testMatrixResultD = null; //FxE
        private int[,] testMatrixResultE = { { 776, 3708, 7228 }, { 50930, 232981, 344570 }, { 64900, 310650, 585700 } }; //DXD

        private int[,] testMixedMatrixA = null; //AwB
        private int[,] testMixedMatrixB = { { 1, 6, 7 }, { 10, 1, 500 }, { 100, 450, 1 } }; //CwD
        private int[,] testMixedMatrixC = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }; //AwC
        private int[,] testMixedMatrixD = { { 4, 0, 0 }, { 0, 89, 0 }, { 0, 0, 600 } }; //DwC

        #endregion MATRICES

        #region ARRAYS

        private int[] testArrA = { 1, 2, 3, 4, 5, 6 };
        private int[] testArrB = { 10, 39 };
        private int[] testArrC = { 45, 20, 70, 1, 54, 99 };
        private int[] testArrD = { };
        private int[] testArrE = { 99 };

        private int[] testInvArrA = { 6, 5, 4, 3, 2, 1 };
        private int[] testInvArrB = { 39, 10 };
        private int[] testInvArrC = { 99, 54, 1, 70, 20, 45 };
        private int[] testInvArrD = { };
        private int[] testInvArrE = { 99 };

        #endregion ARRAYS

        #region TIME

        private int testTimeA = 260125;
        private int testTimeB = 3600;
        private int testTimeC = 169081;
        private int testTimeD = 333905;
        private int testTimeE = 7689;
        private int testTimeF = 18058;

        private string testTimeResultA = string.Format(TIME_FORMAT, 72, 15, 25);
        private string testTimeResultB = string.Format(TIME_FORMAT, 1, 0, 0);
        private string testTimeResultC = string.Format(TIME_FORMAT, 46, 58, 1);
        private string testTimeResultD = string.Format(TIME_FORMAT, 92, 45, 5);
        private string testTimeResultE = string.Format(TIME_FORMAT, 2, 8, 9);
        private string testTimeResultF = string.Format(TIME_FORMAT, 5, 0, 58);

        #endregion TIME

        #region CIRCLES

        private Centro testCenterA = new Centro(4, 1);
        private float testRadiusA = 5;

        private Centro testCenterB = new Centro(14, 1);

        private Centro testCenterC = new Centro(5, 4);
        private float testRadiusC = 10F;

        private Centro testCenterD = new Centro(4, 6);
        private float testRadiusD = 4F;

        #endregion CIRCLES

        #endregion TEST_VARS

        [TestMethod()]
        public void SePuedenSumarMatrices_Test()
        {
            Assert.AreEqual(true, testProgram.SePuedenSumarMatrices(testMatrixD, testMatrixD));
            Assert.AreEqual(false, testProgram.SePuedenSumarMatrices(testMatrixA, testMatrixB));
            Assert.AreEqual(false, testProgram.SePuedenSumarMatrices(testMatrixE, testMatrixF));
            Assert.AreEqual(true, testProgram.SePuedenSumarMatrices(testMatrixA, testMatrixD));
            Assert.AreEqual(true, testProgram.SePuedenSumarMatrices(testMatrixD, testMatrixD));
        }

        [TestMethod()]
        public void PromedioDeArreglo_Test()
        {
            Assert.AreEqual(3.5F, testProgram.PromedioDeArreglo(testArrA), DELTA_ACC);
            Assert.AreEqual(24.5F, testProgram.PromedioDeArreglo(testArrB), DELTA_ACC);
            Assert.AreEqual(48.1667F, testProgram.PromedioDeArreglo(testArrC), DELTA_ACC);
            Assert.AreEqual(0F, testProgram.PromedioDeArreglo(testArrD), DELTA_ACC);
            Assert.AreEqual(99F, testProgram.PromedioDeArreglo(testArrE), DELTA_ACC);
        }

        [TestMethod()]
        public void ConteoDeCaracter_Test()
        {
            Assert.AreEqual(2, testProgram.ConteoDeCaracter("esternon", 'n'));
            Assert.AreEqual(0, testProgram.ConteoDeCaracter("uchuva", 'e'));
            Assert.AreEqual(4, testProgram.ConteoDeCaracter("totolamomposina", 'o'));
            Assert.AreEqual(4, testProgram.ConteoDeCaracter(@"testProgram.ConteoDeCaracter("", 'a');", 'e'));
            Assert.AreEqual(3, testProgram.ConteoDeCaracter("este examen no puede estar mas ganable", 'n'));
        }

        [TestMethod()]
        public void InvertirArreglo_Test()
        {
            CollectionAssert.AreEqual(testInvArrA, testProgram.InvertirArreglo(testArrA));
            CollectionAssert.AreEqual(testInvArrB, testProgram.InvertirArreglo(testArrB));
            CollectionAssert.AreEqual(testInvArrC, testProgram.InvertirArreglo(testArrC));
            CollectionAssert.AreEqual(testInvArrD, testProgram.InvertirArreglo(testArrD));
            CollectionAssert.AreEqual(testInvArrE, testProgram.InvertirArreglo(testArrE));
        }

        [TestMethod()]
        public void EsPalindromo_Test()
        {
            Assert.AreEqual(true, testProgram.EsPalindromo("ABBA"));
            Assert.AreEqual(false, testProgram.EsPalindromo("vampiro"));
            Assert.AreEqual(true, testProgram.EsPalindromo("anitalavalatina"));
            Assert.AreEqual(false, testProgram.EsPalindromo("valentina"));
            Assert.AreEqual(true, testProgram.EsPalindromo("12345654321"));
        }

        [TestMethod()]
        public void CalcularFibonacciEn_Test()
        {
            Assert.AreEqual(55, testProgram.CalcularFibonacciEn(10));
            Assert.AreEqual(377, testProgram.CalcularFibonacciEn(14));
            Assert.AreEqual(5702887, testProgram.CalcularFibonacciEn(34));
            Assert.AreEqual(102334155, testProgram.CalcularFibonacciEn(40));
            Assert.AreEqual(3, testProgram.CalcularFibonacciEn(4));
        }

        [TestMethod()]
        public void MultiplicarMatrices_Test()
        {
            CollectionAssert.AreEqual(testMatrixResultA, testProgram.MultiplicarMatrices(testMatrixA, testMatrixF));
            CollectionAssert.AreEqual(testMatrixResultB, testProgram.MultiplicarMatrices(testMatrixC, testMatrixD));
            CollectionAssert.AreEqual(testMatrixResultC, testProgram.MultiplicarMatrices(testMatrixE, testMatrixF));
            CollectionAssert.AreEqual(testMatrixResultD, testProgram.MultiplicarMatrices(testMatrixF, testMatrixE));
            CollectionAssert.AreEqual(testMatrixResultE, testProgram.MultiplicarMatrices(testMatrixD, testMatrixD));
        }

        [TestMethod()]
        public void FormatearTiempo_Test()
        {
            Assert.AreEqual(testTimeResultA, testProgram.FormatearTiempo(testTimeA));
            Assert.AreEqual(testTimeResultB, testProgram.FormatearTiempo(testTimeB));
            Assert.AreEqual(testTimeResultC, testProgram.FormatearTiempo(testTimeC));
            Assert.AreEqual(testTimeResultD, testProgram.FormatearTiempo(testTimeD));
            Assert.AreEqual(testTimeResultE, testProgram.FormatearTiempo(testTimeE));
        }

        [TestMethod()]
        public void HayColisión_Test()
        {
            Assert.AreEqual(true, testProgram.HayColisión(testCenterA, testRadiusA, testCenterB, testRadiusA));
            Assert.AreEqual(false, testProgram.HayColisión(testCenterA, testRadiusA, testCenterC, testRadiusC));
            Assert.AreEqual(true, testProgram.HayColisión(testCenterB, testRadiusA, testCenterD, testRadiusD));
        }

        [TestMethod()]
        public void ProximoPrimo_Test()
        {
            Assert.AreEqual(23, testProgram.ProximoPrimo(20));
            Assert.AreEqual(2, testProgram.ProximoPrimo(1));
            Assert.AreEqual(223, testProgram.ProximoPrimo(212));
            Assert.AreEqual(653, testProgram.ProximoPrimo(650));
            Assert.AreEqual(127, testProgram.ProximoPrimo(115));
        }

        [TestMethod()]
        public void CombinaMatrices_Test()
        {
            CollectionAssert.AreEqual(testMixedMatrixA, testProgram.CombinaMatrices(testMatrixA, testMatrixB));
            CollectionAssert.AreEqual(testMixedMatrixB, testProgram.CombinaMatrices(testMatrixC, testMatrixD));
            CollectionAssert.AreEqual(testMixedMatrixC, testProgram.CombinaMatrices(testMatrixA, testMatrixC));
            CollectionAssert.AreEqual(testMixedMatrixD, testProgram.CombinaMatrices(testMatrixD, testMatrixC));
            CollectionAssert.AreEqual(testMixedMatrixA, testProgram.CombinaMatrices(testMatrixE, testMatrixF));
        }
    }
}