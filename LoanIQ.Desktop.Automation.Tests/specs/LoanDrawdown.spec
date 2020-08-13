Loan Drawdown
========================================
@LoanDrawdown

01 Create Loan Drawdown Via Favorites
----------------------------------------
// * Login as "digitaf1" and password "password1"
* Select Item "DEAL_TEST" From Favorites
* Select Context MenuItem "Outstanding"
* Create New Outstanding Select
    | Field                 | Value             |
    |-----------------------|-------------------|
    | Pricing Option        | Libor Option      |

* Close Drawdown Libor Option Initial Window Without Saving

02 Create Loan Drawdown Via Outstanding Icon
----------------------------------------
* Select Action "Outstanding"
* Create New Outstanding Select
    | Field                 | Value             |
    |-----------------------|-------------------|
    | Deal                  | BIL DEAL          |

* Close Drawdown Libor Option Initial Window Without Saving

03 Create Loan Drawdown Via Deal Notebook Query Outstanding Select
----------------------------------------
* Select Action "Deal"
* Select Existing Deal "BIL DEAL"
* Select Outstanding Select From Deal Notebook Window
* Create New Outstanding Select
    | Field                 | Value             |
    |-----------------------|-------------------|
    | Deal                  | BIL DEAL          |

* Close Drawdown Libor Option Initial Window Without Saving

04 Create Loan Drawdown Via Deal Facility Query Outstanding Select
----------------------------------------
* Select Action "Facility"
* Populate Facility Select
    | Field                 | Value             |
    |-----------------------|-------------------|
    | Deal                  | BIL DEAL          |
    | Name                  | REVOLVER          |

* Create Outstanding Select From Facility Window
* Populate General Tab In Libor Option Initial Drawdown Window
    | Field                 | Value             |
    |-----------------------|-------------------|
    | Effective Date        | 10-Jun-2014       |
    | Maturity Date         | 10-Jun-2015       |
    | Amounts Requested     | 1000              |
    | Repricing Date        | 10-Jun-2015       |
    | Repricing Frequency   | 1 Days            |
    | Int Cycle Frequency   | Daily             |

* Set Base Rate With "10" And Ovveride Spread With "5"
* Populate Code And Calendars Tab
    | Field                    | Value                  |
    |--------------------------|------------------------|
    | Treasury Reporting Area  | Philippines            |
    | Calendar                 | ASIA Holiday Calendar  |

* Create Cash Flow