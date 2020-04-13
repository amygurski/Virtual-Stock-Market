USE StockMarketDB
GO

--150 stocks to use for testing (these are the daily ones for buy/sell)
BEGIN TRANSACTION;
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'AAL', N'American Airlines Gp', 12.510000228881836, 10.409999847412109)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'AAPL', N'Apple Inc', 267.989990234375, 0.72000002861022949)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'ABBV', N'Abbvie Inc', 79.75, 1.5099999904632568)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'ABT', N'Abbott Laboratories', 86.040000915527344, 1.2799999713897705)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'ACB', N'Aurora Cannabis Inc', 0.87629997730255127, 2.8299999237060547)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'ADBE', N'Adobe Systems Inc', 318.70001220703125, 0.47999998927116394)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'AMC', N'Amc Entertainment Holdings Inc', 2.5999999046325684, -21.209999084472656)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'AMD', N'Adv Micro Devices', 48.380001068115234, -0.8399999737739563)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'AMRN', N'Amarin Corp Ads', 6.0500001907348633, 4.130000114440918)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'AMZN', N'Amazon.com Inc', 2042.760009765625, -0.0099999997764825821)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'APA', N'Apache Corp', 8.1999998092651367, 8.1800003051757812)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'APT', N'Alpha Pro Tech', 12.300000190734863, -5.380000114440918)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'ATVI', N'Activision Blizzard', 60.459999084472656, -1)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'AVGO', N'Broadcom Ltd', 254.30000305175781, -2.5999999046325684)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'AXP', N'American Express Company', 94.819999694824219, 2.9800000190734863)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'BA', N'Boeing Company', 151.83999633789063, 3.380000114440918)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'BABA', N'Alibaba Group Holding', 196.3699951171875, 0.20000000298023224)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'BAC', N'Bank of America Corp', 24.940000534057617, 6.3499999046325684)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'BBBY', N'Bed Bath & Beyond', 5.5799999237060547, -2.1099998950958252)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'BIDU', N'Baidu Inc', 99, 1.7200000286102295)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'BMY', N'Bristol-Myers Squibb Company', 58.909999847412109, 1.1299999952316284)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'BP', N'BP Plc', 24.899999618530273, -1.9299999475479126)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'BYND', N'Beyond Meat Inc', 72.300003051757812, 4.070000171661377)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'C', N'Citigroup Inc', 47.409999847412109, 7.119999885559082)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'CAT', N'Caterpillar Inc', 125.02999877929688, -1.8600000143051148)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'CCL', N'Carnival Corp', 12.420000076293945, 3.5899999141693115)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'CGC', N'Canopy Growth Corp', 14.569999694824219, -1.75)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'CHWY', N'Chewy Inc', 42.610000610351562, 15.380000114440918)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'CMCSA', N'Comcast Corp A', 38, 0.85000002384185791)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'COP', N'Conocophillips', 34.729999542236328, -2.6600000858306885)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'COST', N'Costco Wholesale', 300.010009765625, -1.9500000476837158)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'CRM', N'Salesforce.com Inc', 154.55000305175781, 2.2699999809265137)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'CSCO', N'Cisco Systems Inc', 41.200000762939453, -1.2899999618530273)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'CVS', N'CVS Corp', 60.470001220703125, 1.7799999713897705)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'CVX', N'Chevron Corp', 84.30999755859375, -1.940000057220459)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'DAL', N'Delta Air Lines Inc', 24.389999389648438, 4.9899997711181641)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'DIS', N'Walt Disney Company', 104.5, 3.3900001049041748)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'DOCU', N'Docusign Inc', 90.629997253417969, 2.559999942779541)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'DVN', N'Devon Energy Corp', 9.6700000762939453, 2.7599999904632568)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'EWJ', N'Japan Ishares MSCI ETF', 50.380001068115234, 1.309999942779541)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'EXPE', N'Expedia Group Inc', 62.419998168945312, 3.0899999141693115)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'F', N'Ford Motor Company', 5.369999885559082, 6.7600002288818359)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'FB', N'Facebook Inc', 175.19000244140625, 0.51999998092651367)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'FCAU', N'Fiat Chrysler Automobiles N.V.', 8.2100000381469727, 4.4499998092651367)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'FCX', N'Freeport-Mcmoran Inc', 8.1899995803833, 1.9900000095367432)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'FDX', N'Fedex Corp', 122.29000091552734, -2.5899999141693115)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'FIT', N'Fitbit Inc', 6.75, 2.2699999809265137)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'GE', N'General Electric Company', 7.1399998664855957, -2.190000057220459)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'GILD', N'Gilead Sciences Inc', 73.510002136230469, -1.9700000286102295)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'GM', N'General Motors Company', 24.059999465942383, 4.0199999809265137)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'GME', N'Gamestop Corp', 3.8900001049041748, 14.079999923706055)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'GOLD', N'Barrick Gold Corp', 22.510000228881836, 10.289999961853027)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'GOOG', N'Alphabet Cl C', 1211.449951171875, 0.10000000149011612)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'GOOGL', N'Alphabet Cl A', 1206.5699462890625, -0.039999999105930328)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'GRUB', N'Grubhub Inc', 45.090000152587891, 3.0899999141693115)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'GS', N'Goldman Sachs Group', 184.25999450683594, 4.130000114440918)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'GSX', N'Gsx Techedu Inc ADR', 33.159999847412109, 8.8299999237060547)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'HAL', N'Halliburton Company', 8.2100000381469727, -6.1700000762939453)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'HD', N'Home Depot', 201.52999877929688, 3.440000057220459)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'HEXO', N'Hexo Corp', 0.50760000944137573, -2.0099999904632568)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'HPQ', N'HP Inc', 15.970000267028809, 1.5900000333786011)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'HSBC', N'HSBC Holdings Plc', 26.760000228881836, 2.880000114440918)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'IBM', N'International Business Machines', 121.5, 1.8500000238418579)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'IMMU', N'Immunomedics Inc', 19.639999389648438, 6.570000171661377)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'INO', N'Inovio Pharma', 8.119999885559082, -2.4000000953674316)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'INTC', N'Intel Corp', 57.139999389648438, -3.119999885559082)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'IQ', N'Iqiyi Inc ADR', 17.3700008392334, 5.2100000381469727)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'JD', N'Jd.com Inc Ads', 42.159999847412109, 2.4000000953674316)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'JNJ', N'Johnson & Johnson', 141.22999572753906, -1.4199999570846558)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'JPM', N'JP Morgan Chase & Company', 102.76000213623047, 8.9700002670288086)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'KHC', N'Kraft Heinz Company', 28.110000610351562, 2.8900001049041748)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'KO', N'Coca-Cola Company', 49, 2.4700000286102295)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'KOD', N'Kodiak Sciences Inc', 50.669998168945312, 8.8500003814697266)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'KSS', N'Kohl''s Corp', 19.909999847412109, 13.640000343322754)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'LB', N'L Brands Inc', 14.930000305175781, 2.4000000953674316)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'LK', N'Luckin Coffee Inc ADR', 4.3899998664855957, -18.399999618530273)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'LUV', N'Southwest Airlines Company', 36.470001220703125, 6.3299999237060547)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'LVS', N'Las Vegas Sands', 47.860000610351562, 2.809999942779541)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'LYFT', N'Lyft Inc Cl A', 30.329999923706055, 2.3299999237060547)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'LYV', N'Live Nation Entertainment', 38.270000457763672, 1.3500000238418579)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'M', N'Macy''s Inc', 6.6599998474121094, 10.819999694824219)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'MA', N'Mastercard Inc', 269.39999389648438, -0.56999999284744263)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'MAR', N'Marriot Int Cl A', 81.30999755859375, -1.4800000190734863)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'MCD', N'McDonald''s Corp', 183.69999694824219, 3.5)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'MGM', N'MGM Resorts International', 14.550000190734863, -3)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'MMM', N'3M Company', 147.77999877929688, -0.81000000238418579)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'MO', N'Altria Group', 40.909999847412109, 1.940000057220459)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'MRK', N'Merck & Company', 82.489997863769531, 1.0700000524520874)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'MRNA', N'Moderna Inc', 31.860000610351562, -1.7300000190734863)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'MRO', N'Marathon Oil Corp', 4.119999885559082, 4.3000001907348633)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'MRVL', N'Marvell Tech Group', 24.280000686645508, -1.8600000143051148)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'MS', N'Morgan Stanley', 41.080001831054688, 4.3400001525878906)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'MSFT', N'Microsoft Corp', 165.13999938964844, 0.0099999997764825821)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'MU', N'Micron Technology', 46.130001068115234, -4.46999979019165)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'NCLH', N'Norwegian Cruise Ord', 13.109999656677246, 11.859999656677246)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'NEM', N'Newmont Mining Corp', 57.310001373291016, 13.420000076293945)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'NFLX', N'Netflix Inc', 370.72000122070312, -0.10999999940395355)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'NKE', N'Nike Inc', 86.790000915527344, 1.75)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'NLY', N'Annaly Capital Management Inc', 6.070000171661377, 5.570000171661377)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'NRZ', N'New Residential Investment Corp', 5.75, 12.520000457763672)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'NVDA', N'Nvidia Corp', 262.95001220703125, -1.5)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'OXY', N'Occidental Petroleum Corp', 15.359999656677246, -1.2899999618530273)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'PBR', N'Petroleo Brasileiro S.A. Petrobras', 6.71999979019165, -1.3200000524520874)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'PCG', N'Pacific Gas & Electric Company', 11.989999771118164, 10)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'PDD', N'Pinduoduo Inc ADR', 41.040000915527344, 3.3499999046325684)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'PENN', N'Penn Natl Gaming Inc', 13.909999847412109, 7.9099998474121094)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'PFE', N'Pfizer Inc', 35.389999389648438, 2.2799999713897705)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'PG', N'Procter & Gamble Company', 114.66000366210938, -0.37999999523162842)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'PINS', N'Pinterest Inc', 16.75, -0.47999998927116394)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'PTON', N'Peloton Interactive Inc', 28.450000762939453, 3.4500000476837158)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'PYPL', N'Paypal Holdings', 105.83999633789063, 0.74000000953674316)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'QCOM', N'Qualcomm Inc', 71.580001831054688, -2.3900001049041748)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'RCL', N'Royal Caribbean Cruises Ltd', 40.220001220703125, 7.0799999237060547)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'ROKU', N'Roku Inc', 92.449996948242188, 5.28000020980835)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'SAN', N'Banco Santander', 2.3399999141693115, -3.309999942779541)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'SBUX', N'Starbucks Corp', 73.879997253417969, 3.2300000190734863)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'SDC', N'Smiledirectclub Inc', 4.3600001335144043, 0.23000000417232513)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'SE', N'Sea Ltd ADR', 45.069999694824219, -0.8399999737739563)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'SGMS', N'Scientific Games', 9.1499996185302734, 3.3900001049041748)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'SHOP', N'Shopify Inc', 417.739990234375, 0.77999997138977051)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'SLB', N'Schlumberger N.V.', 16.469999313354492, -4.690000057220459)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'SNAP', N'Snap Inc', 13.609999656677246, 2.9500000476837158)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'SPCE', N'Virgin Galactic Holdings Inc', 15.270000457763672, -0.5899999737739563)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'SQ', N'Square', 59.209999084472656, 3.7999999523162842)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'T', N'AT&T Inc', 30.729999542236328, 2.809999942779541)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'TAL', N'Tal Education Group', 50.819999694824219, -2.380000114440918)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'TEVA', N'Teva Pharmaceutical Industries Ltd', 10.159999847412109, 3.25)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'TGT', N'Target Corp', 104.19999694824219, -0.40999999642372131)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'TLRY', N'Tilray Inc', 6.78000020980835, -2.869999885559082)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'TSLA', N'Tesla Inc', 573, 4.4000000953674316)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'TWTR', N'Twitter Inc', 27.770000457763672, -0.31999999284744263)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'UAL', N'United Continental Holdings', 31.5, 14.5)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'UBER', N'Uber Technologies Inc', 27.110000610351562, 0.62999999523162842)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'UCO', N'Ultra DJ-UBS Crude Oil Proshares', 2.0199999809265137, -14.409999847412109)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'UNH', N'Unitedhealth Group Inc', 264.1300048828125, -1.3799999952316284)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'V', N'Visa Inc', 173.69000244140625, -0.70999997854232788)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'VALE', N'Vale S.A.', 8.5, 0.70999997854232788)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'VIAC', N'Viacomcbs Inc. Cl B', 16.559999465942383, 4.880000114440918)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'VZ', N'Verizon Communications Inc', 57.439998626708984, -0.62000000476837158)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'W', N'Wayfair Inc', 76.8499984741211, -1.1799999475479126)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'WBA', N'Walgreens Boots Alliance', 43.979999542236328, 2.0699999332427979)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'WFC', N'Wells Fargo & Company', 33.200000762939453, 9.6400003433227539)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'WMT', N'Wal-Mart Stores', 121.80000305175781, -0.029999999329447746)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'WORK', N'Slack Technologies Inc', 24.700000762939453, -0.800000011920929)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'WYNN', N'Wynn Resorts Ltd', 70.6500015258789, 2.2899999618530273)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'X', N'United States Steel Corp', 6.809999942779541, 0.74000000953674316)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'XLK', N'S&P 500 Info Tech Sector SPDR', 85.199996948242188, 0.019999999552965164)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'XOM', N'Exxon Mobil Corp', 43.130001068115234, -1.6399999856948853)
GO
INSERT [dbo].[stocks] ([stock_symbol], [name_of_company], [current_share_price], [percent_daily_change]) VALUES (N'ZM', N'Zoom Video Communications Cl A', 124.51000213623047, 5.690000057220459)
GO
COMMIT TRANSACTION;


-- Add System Transaction "Stock" to stocks table used for player starting balance and end of game cashout transactions
BEGIN TRANSACTION;

INSERT INTO stocks
	(stock_symbol, name_of_company, current_share_price, percent_daily_change)
VALUES
	('SYSTRN', 'System Transaction', 1, 0);

COMMIT TRANSACTION;


-- Seed database with some transactions for testing
BEGIN TRANSACTION;

INSERT INTO transactions
	(user_id, game_id, stock_symbol, number_of_shares, transaction_share_price, transaction_date, is_buy, net_transaction_change)
VALUES
	(1, 1653,'SYSTRN', 1, 100000.00, '2020-01-01', 0, 100000.00),
	(1, 1654,'SYSTRN', 1, 100000.00, '2020-01-01', 0, 100000.00),
	(1, 1655,'SYSTRN', 1, 100000.00, '2020-01-01', 0, 100000.00),
	(1, 1656,'SYSTRN', 1, 100000.00, '2020-01-01', 0, 100000.00),
	(1, 1657,'SYSTRN', 1, 100000.00, '2020-03-01', 0, 100000.00),
	(1, 1653,'AAPL', 100, 250.778, '2020-03-15', 1, -25077.8),
	(1, 1653,'BAC', 50, 27.115, '2020-03-22', 1, -1355.75),
	(1, 1653,'CVX', 72, 81.22114, '2020-03-29', 1, -5847.92208),
	(1, 1653,'GS', 133, 192.8876, '2020-04-01', 1, -25654.0508),
	(1, 1653,'AAPL', 100, 267.989990234375, '2020-04-03', 0, 26798.9990234375),
	(1, 1653,'CVX', 72, 77.2143, '2020-04-06', 0, 5559.4296);

COMMIT TRANSACTION;
