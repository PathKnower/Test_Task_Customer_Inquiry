# Software Architect Technical Assignment Customer Inquiry


# Description
Implement a service to provide customer inquiry and return result, which contains customer detail and its recent payment history.
Use best practices and design patterns, skills in design/architecture, ability to build testable and maintainable software.
## Domain

### Inquiry Criteria
1. Customer ID (Numeric, max 10 digits)
2. Email (Valid email format, max 25 digits)

#### Customer
1. Customer ID (Numeric, 10 digits)
2. Customer Name (Character max 30 chars)
3. Contact Email (Max 25 digits)
4. Mobile No (Numeric 10 digits)
5. List of recent transaction (Up to 5 records)

### Transaction
1. Transaction ID (Numeric)
2. Transaction Date/Time (DD/MM/YY HH:MM e.g. 31/02/2018 21:34)
3. Amount (2 decimal points e.g. 100.00, 1234.56 or 1.99)
4. Currency Code (e.g. USD, JPY, THB or SGD)
5. Status (Success, Failed or Canceled)

## Validation Rules
1. At least 1 of the inquiry criteria must be provided. Unless return Bad Request with one of the following error message:
a. No inquiry criteria
b. Invalid Customer ID
c. Invalid Email
2. If inquiry criteria doesn’t match any record on the database, return result as “Not found”
3. The rest of the case is Bad Request with no error message.
4. Assume Customer ID and Email are unique to a particular customer.
## Sample Requests
### Request Scenario #1 inquiry with Customer ID:
```
{
"customerID": 123456
}
```
### Request Scenario #2 inquiry with Email 
```
{
"email": "user @domain.com"
}
```
### Request Scenario #3 inquiry with both attributes 
```
{
"customerID": 123456,
"email": "user @domain.com"
}
```
## Sample Responses
### Response Scenario #1 Customer profile with no transaction 
```
{
"customerID": 123456,
"name": "Firstname Lastname",
"email": "user @domain.com",
"mobile": "0123456789",
"transactions": []
} 
```
### Response Scenario #2 Customer profile with 1 transaction 
```
{
"customerID": 123456,
"name": "Firstname Lastname",
"email": "user @domain.com",
"mobile": "0123456789",
"transactions": [{
"id": 1,
"date": "31/02/2018 21:34",
"amount": "1234.56",
"currency": "USD",
"status": "Success"
}]
}
```
### Response Scenario #3 Customer profile with multiple transactions 
```
{
"customerID": 123456,
"name": "Firstname Lastname",
"email": "user @domain.com",
"mobile": "0123456789",
"transactions": [
{
"id": 1,
"date": "31/02/2018 21:34",
"amount": "1234.56",
"currency": "USD",
"status": "Success"
},
{
"id": 2,
"date": "01/11/2018 08:34",
"amount": "0.56",
"currency": "THB",
"status": "Failed"
}]
}
```
### Server side
- Web API
### Database
- MS SQL Server, please create 2 tables: 1. Customers 2. Transactions
- Entity Framework to retrieve data
### Time frame
24 hours. 
