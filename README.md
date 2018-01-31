# Explain This Crypto

## Overview

The cryptocurrency market has experienced an explosive growth in the past year alone. The number of cryptocurrency project launched has increase from just a mere handful to more than a thousand in the span of just one year.

As cryptocurrencies becomes more popular and attracts mainstream attention, we see a surge in public demand to understand the many cryptocurrency projects listed on the market.

While the internet is filled with descriptions of the different cryptocurrencies, many descriptions are poorly drafted, generalized, incomplete or worse - inaccurate. We attribute this credibility issue to the lack of accountability and moderation over the scattered platforms and channels.

This project seeks to solve this problem by creating a platform that would provide credible information and description of cryptocurrencies.  

## Specifications

This application will perform the following functions:

#### User Stories

1. As a visitor, I can view a list of featured cryptocurrencies on the homepage. Each coin will have the following information displayed: _Logo_, _Ticker Symbol_, _Description_ and _Author_.

1.  As a visitor, I can search for a coin from the search bar at the top of the homepage.

1. As a visitor, I can click and view a particular coin and all the descriptions of that coin.

1. As an admin, I can create/ update/ delete the description of any coin.

#### Proposed Tools






| ID| User Stories  |Behaviour      |
|---| ------------- |:-------------:|
| 1 | col 3 is      | right-aligned |
| 2 | col 2 is      | centered      |
| 3 | zebra stripes | are neat      |

## Future Development

#### Expanding Functionality

Implementing an upvoting system and user authentication. Great descriptions will get upvoted and bad descriptions can get flagged and reported. Users will be allowed to create/ update and delete descriptions that they created.

#### API Functionalities

An JSON Format example of an API for BTC and ETH:

```
{
  "coin": [
           {
             "name": "Bitcoin",
             "ticker": "BTC",
             "description": [
                             {
                               "author": "Nat Lewis",
                               "content": "Digital Gold",
                               "rating": 5.4,
                               },
                             {
                               "author": "Satoshi Nakamoto",
                               "content": "Digital Cash",
                               "rating": 10,
                             },
             "logo": "https://bitcoin.org/img/icons/opengraph.png"                          
             ]
           },
           {
             "name": "Ethereum",
             "ticker": "ETH",
             "description": [
                             {
                               "author": "Nat Lewis",
                               "content": "The most popular smart contract platform",
                               "rating": 5.4,
                               },
             "logo": "https://www.ethereum.org/images/logos/ETHEREUM-ICON_Black_small.png"                  
             ]
           },
  ]
}
```

## Resources

The onboarding of public interest has given rise to a host of cryptocurrency information providers of which some are listed below:

* [coinmarketcap.com](coinmarketcap.com) & [coingecko.com](coingecko.com) - Tracks Coin Prices, Market Cap, Volume Traded, and basic information.

* [cryptocompare.com](cryptocompare.com) - Tracks coin Prices, a review platform for various topics such as mining, crypto exchanges, etc.

* [coindesk.com](coindesk.com) & [cointelegraph.com](cointelegraph.com) - Provides cryptocurrency news updates and opinion articles.

* [99bitcoins.com](99bitcoins.com) - Provides guides and reviews on cryptocurrencies that is aimed at beginners and intermediates.

*  [blockgeeks.com](blockgeeks.com) - Teaching people about blockchain and programming smart contracts.
