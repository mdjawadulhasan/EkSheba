Auth Controller : 

User Register [POST]  api/login/add
-Check if username is used or not
"Uname": "Hasan",
   	   "Password": "52923",
      		"Type":"2"

Login [POST]  api/login/
-Expiration Time checked (15 minutes given)
User : If blocked , then cant login to the system.
"Uname": "Hasan",
   	   "Password": "52923",




User Controller : 

User Details Add [POST] api/users/add
{    
    "Name": "Jawadul Hasan",
    "Age": "22",
    "Adress": "Banasree",
    "PhoneNo": "01707615220",
    "Religion": "Islam",
    "FathersName": "Md. Mohosin Miah",
    "MotherName": "Asma Khatun",

}
User Details Update [Post]  api/users/update
{  
    "Nid":"7",
    "Name": "Jawadul Islam",
    "Age": "22",
    "Adress": "Banasree",
    "PhoneNo": "01707615220",
    "Religion": "Islam",
    "FathersName": "Md. Mohosin Miah",
    "MotherName": "Asma Khatun",
    "Status":"0",
    "FK_Uid":"12"      
}

Bank Account Create Request [Post] api/users/bank/reqaccount
-Check if there already pending request 

Account Recharge with Scratchcards [Post] api/users/bank/Recharge 
-Pre condition : Account has to be activated by Admin
-Scratchcard used by this user will be invalid for further use.
-Transaction history table will be updated with this new transactions
{            
   "Token": "bac181cd-a201-44c5-9415-b77c6bdd98b4"       
}

Passport Apply [Post] api/users/passport/apply/type
Type : 1/2/3 [Urgent /Normal/ Renew]
-Pre conditions :
- Sufficient balance with active account
	-Check if already request exists
	-Balance will updated according to the passport type
	

Add Income Tax  [Post]  api/users/Tax/addincome
        -Tax will calculated based on BD tax calculation algorithm and create a row   in tax table with the taxable amount
        - Check if already exists or not
        
 {
             
    "BasicSalary": "1000000",
    "HouseRent": "200000",
    "MedicalAllowancw": "500000",
    "Conveyance": "200000",
    "Incentive": "100000",
    "FestivalBonus": "300000"
      
}
Update Income Tax  [Post]  api/users/Tax/updateincome
Can only update current year data
{
             
    "BasicSalary": "1000000",
    "HouseRent": "200000",
    "MedicalAllowancw": "500000",
    "Conveyance": "200000",
    "Incentive": "100000",
    "FestivalBonus": "400000",
    "id":"4",
    "Year":"2022",
    "Fis_FK_NID":"7"
      
}

Pay Tax [Post] api/users/Tax/PayTax
	- Check if account balance > desirable paid amount
	- Tax Paying history will stored inside another table
	- Account Balance will be updated

{
    "Id":"3",
    "IN_FK_NID":"7",
    "Paid":"1000"
}

User Academic Info [Get]  api/user/academicinfo
- See Academic results that are updated by Education Admin

 Job Application [Get]  api/jobapplication/apply/{id}
- Check if already application exists [job id & user id checked]
- Check if sufficient(500) balance is available 
-Account Balance will be updated
Admin Controller : 

See All users [GET] api/login/users 
Delete Users [GET] api/login/delete/{id} 
See Specific User [GET] api/login/user/{id} 
See All users Details [GET] api/users 
Active Users [POST] api/user/active/{id} 
Block User [POST] api/user/block/{id}  
View Bank Account [GET] api/admin/BankAccount/accounts
Accept Bank account [GET] api/admin/BankAccount/AcceptAccount/{id}
Block Bank Account [GET] api/admin/BankAccount/BlockAccount/{id} 
Delete Bank Account [GET] api/admin/BankAccount/delete/{id}
Generate recharge scratchcard [GET] api/admin/BankAccount/genratetoken
10 scratchcard will generate with unique token worth 5000 taka on each
View Passport Applications [GET] api/admin/passport/applications
View Passports [GET] api/admin/passports
Accept  Passport Application request [GET] api/admin/passport/Accept/{id}
Block Passport [GET] api/admin/passport/Block/{id}
Active Passport [GET] api/admin/passport/Active/{id}
CRUD User Acadmic Info 
CRUD Job application
CRUD Job Circular
