using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Logic.Entities.Transactions;
using PromotionEngine.Logic.Implementations.DataUnits;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.MS.Testing
{
    [TestClass]
    public class ScenarioBPositive
    {
        #region Declaraction

        DataUnitDetails dataUnitDetails = new DataUnitDetails();
        List<CartItemDetails> cartItemDetails = new List<CartItemDetails>();
        int expected;
        #endregion Declaraction

        #region Test Initialization
        /// <summary>
        /// Initialization Test Value
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
            cartItemDetails.Add(new CartItemDetails { SKUName = "A", SKUQty = 5, IsApplyPromo = false });
            cartItemDetails.Add(new CartItemDetails { SKUName = "B", SKUQty = 5, IsApplyPromo = false });
            cartItemDetails.Add(new CartItemDetails { SKUName = "C", SKUQty = 1, IsApplyPromo = false });
            expected = 370;
        }
        #endregion Test Initialization

        #region Testing
        /// <summary>
        /// Execuate Testing Here
        /// </summary>
        [TestMethod]
        public void ScenarioBPositiveTesting()
        {
            //Assert 
            decimal TotalAmount = dataUnitDetails.GetBillDetails(cartItemDetails).Sum(sum => sum.TotalAmount);

            //Act
            Assert.IsTrue(expected.Equals(Convert.ToInt32(TotalAmount)));
        }

        #endregion Testing

        #region Test Clean Up
        /// <summary>
        /// Clear Variable and Object
        /// </summary>
        [TestCleanup]
        public void TestClear()
        {
            dataUnitDetails = null;
            cartItemDetails = null;
            expected = 0;
        }
        #endregion Test Clean Up
    }
}
