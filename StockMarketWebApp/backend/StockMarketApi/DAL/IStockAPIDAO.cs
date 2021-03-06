﻿using System.Collections.Generic;
using StockMarketApi.Models.DatabaseModels;

namespace StockMarketApi.DAL
{
    /// <summary>
    /// Interface for public stock market API data
    /// </summary>
    public interface IStockAPIDAO
    {
        /// <summary>
        /// List of stocks from public API
        /// </summary>
        /// <returns></returns>
        List<StockModel> GetCurrentStockPrices();
    }
}