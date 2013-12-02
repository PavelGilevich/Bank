using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///Это класс теста для CheckingAccountTest, в котором должны
    ///находиться все модульные тесты CheckingAccountTest
    ///</summary>
    [TestClass()]
    public class CheckingAccountTest
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
        ///Тест для CheckFee
        ///</summary>
        [TestMethod()]
        public void CheckBalanceTest()
        {
            int number = 0; // TODO: инициализация подходящего значения
            string password = string.Empty; // TODO: инициализация подходящего значения
            double balance = 100; // TODO: инициализация подходящего значения
            DateTime openDate = new DateTime(2013,1,1); // TODO: инициализация подходящего значения
            int monthlyQuota = 1; // TODO: инициализация подходящего значения
            double fee = 30; // TODO: инициализация подходящего значения
            CheckingAccount target = new CheckingAccount(number, password, balance, openDate, monthlyQuota, fee); // TODO: инициализация подходящего значения
            target.PutMoney(10, new DateTime(2013, 1, 4));
            target.PutMoney(5, new DateTime(2013, 1, 9));
            target.WithdrawMoney(5, new DateTime(2013,1,15));
            double expected = 50;
            double actual = target.CheckBalance(new DateTime(2013, 1, 20));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Тест для CountMonths
        ///</summary>
        [TestMethod()]
        public void CountMonthsTest()
        {
            CheckingAccount target = new CheckingAccount();
            DateTime paymentDate = new DateTime(2012, 11, 30);
            DateTime currDate = new DateTime(2013, 4, 28);
            int expected = 4;
            int actual = target.CountMonths(currDate, paymentDate);
            Assert.AreEqual(expected, actual);
        }
    }
}
