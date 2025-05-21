# EkSheba - Integrated E-Government Services Platform

EkSheba is a comprehensive e-government portal that brings multiple public services onto a single platform, including banking, passport applications, income tax management, and job applications. The system is designed to provide Bangladeshi citizens with convenient access to essential government services through a unified interface.

## Features

### User Services
- **Authentication System**
  - User registration with username validation
  - Secure login with token-based authentication (15-minute expiration)
  - User blocking functionality for security purposes

- **Banking Services**
  - Account creation request system
  - Account recharge using scratchcards
  - Transaction history tracking
  - Balance management

- **Passport Services**
  - Application submission for different passport types
  - Automatic fee calculation and balance deduction
  - Application status tracking

- **Tax Management**
  - Income tax calculation based on Bangladesh tax regulations
  - Tax payment processing with balance verification
  - Payment history tracking
  - Current year tax data updates

- **Employment Services**
  - Access to job circulars
  - Online job application submission
  - Application fee processing
  - Application status tracking

- **Educational Records**
  - View academic results updated by Education Admin

### Administration
- **User Management**
  - View all users and their details
  - Activate/block user accounts
  - Delete user accounts

- **Banking Administration**
  - View all bank account requests
  - Accept/reject account requests
  - Block/activate accounts
  - Generate recharge scratchcards with unique tokens

- **Passport Administration**
  - View all passport applications
  - Accept passport applications
  - Block/activate passports

- **Job Application Management**
  - Create, update, and delete job circulars
  - Manage job applications

- **Academic Records Management**
  - CRUD operations for user academic information

## Technical Architecture

### Backend
- **Framework**: ASP.NET Core Web API
- **Database**: Microsoft SQL Server
- **ORM**: Entity Framework Core
- **Authentication**: JWT (JSON Web Tokens)

### API Endpoints

#### Auth Controller
- `POST api/login/add` - User Registration
- `POST api/login/` - User Login

#### User Controller
- `POST api/users/add` - Add User Details
- `POST api/users/update` - Update User Details
- `POST api/users/bank/reqaccount` - Request Bank Account
- `POST api/users/bank/Recharge` - Recharge Account
- `POST api/users/passport/apply/type` - Apply for Passport
- `POST api/users/Tax/addincome` - Add Income Tax
- `POST api/users/Tax/updateincome` - Update Income Tax
- `POST api/users/Tax/PayTax` - Pay Tax
- `GET api/user/academicinfo` - Get Academic Info
- `GET api/jobapplication/apply/{id}` - Apply for Job

#### Admin Controller
- `GET api/login/users` - View All Users
- `GET api/login/delete/{id}` - Delete User
- `GET api/login/user/{id}` - View Specific User
- `GET api/users` - View All User Details
- `POST api/user/active/{id}` - Activate User
- `POST api/user/block/{id}` - Block User
- `GET api/admin/BankAccount/accounts` - View Bank Accounts
- `GET api/admin/BankAccount/AcceptAccount/{id}` - Accept Account
- `GET api/admin/BankAccount/BlockAccount/{id}` - Block Account
- `GET api/admin/BankAccount/delete/{id}` - Delete Account
- `GET api/admin/BankAccount/genratetoken` - Generate Scratchcards
- `GET api/admin/passport/applications` - View Passport Applications
- `GET api/admin/passports` - View Passports
- `GET api/admin/passport/Accept/{id}` - Accept Passport
- `GET api/admin/passport/Block/{id}` - Block Passport
- `GET api/admin/passport/Active/{id}` - Activate Passport

## Business Rules
- Account must be activated by admin before use
- Scratchcards become invalid after first use
- Passport applications require sufficient account balance
- Income tax updates are only allowed for current year data
- Job applications check for duplicate applications and sufficient balance
- Each transaction updates the balance and transaction history

## Installation and Setup

### Prerequisites
- Visual Studio 2019 or later
- .NET Core 5.0 SDK or later
- Microsoft SQL Server
- SQL Server Management Studio (SSMS)

### Setup Instructions
1. Clone the repository
   ```
   git clone https://github.com/mdjawadulhasan/EkSheba.git
   ```
2. Open the solution file in Visual Studio
3. Update the connection string in `appsettings.json` with your SQL Server details
4. Run the following commands in Package Manager Console to set up the database:
   ```
   update-database
   ```
5. Build and run the application

## Future Enhancements
- Mobile application integration
- SMS notification system
- Digital signature implementation
- Additional government services integration
- Enhanced reporting and analytics

## Contributors
- MD. Jawadul Hasan

## License
This project is licensed under the MIT License - see the LICENSE file for details.
