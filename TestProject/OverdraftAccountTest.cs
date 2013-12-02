using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///Это класс теста для OverdraftAccountTest, в котором должны
    ///находиться все модульные тесты OverdraftAccountTest
    ///</summary>
    [TestClass()]
    public class OverdraftAccountTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты теста
        // 
        //При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        //ClassInitialize используется для выполнения кода до запуска первого теста в классе
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //TestInitialize используется для выполнения кода перед запуском каждого теста
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //TestCleanup используется для выполнения кода после завершения каждого теста
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Тест для CheckBalance
        ///</summary>
        [TestMethod()]
        public void CheckBalanceTest()
        {
            int number = 0; // TODO: инициализация подходящего значения
            string password = string.Empty; // TODO: инициализация подходящего значения
            double balance = 10; // TODO: инициализация подходящего значения
            DateTime openDate = new DateTime(2013,1,1); // TODO: инициализация подходящего значения
            double int_rate = 3; // TODO: инициализация подходящего значения
            OverdraftAccount target = new OverdraftAccount(number, password, balance, openDate, int_rate); // TODO: инициализация подходящего значения
            DateTime currDate = new DateTime(2013,5,9); // TODO: инициализация подходящего значения
            target.WithdrawMoney(60, new DateTime(2013, 3, 8));
            double expected = -53.045; // TODO: инициализация подходящего значения
            double actual;
            actual = target.CheckBalance(currDate);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Тест для CountPenalty
        ///</summary>
        [TestMethod()]
        public void CountPenaltyTest()
        {
            int number = 0; // TODO: инициализация подходящего значения
            string password = string.Empty; // TODO: инициализация подходящего значения
            double balance = 10; // TODO: инициализация подходящего значения
            DateTime openDate = new DateTime(2013, 1, 1); // TODO: инициализация подходящего значения
            double int_rate = 5; // TODO: инициализация подходящего значения
            OverdraftAccount target = new OverdraftAccount(number, password, balance, openDate, int_rate); // TODO: инициализация подходящего значения
            DateTime currDate = new DateTime(2013, 4, 1);
            target.WithdrawMoney(20, new DateTime(2013,2,1));
            double expected = 1.025;
            double actual = target.CountPenalty(currDate);
            Assert.AreEqual(expected, actual);
        }
    }
}
