
# EkSheba

## Auth Controller 
1. User Register 
[POST] api/login/add
⦁Check if username is used or not

2. Login 
[POST] api/login/

⦁Expiration Time checked (15 minutes given)
if user is blocked , then cant login to the system.


## User Controller 
1.	User Details Add 
[POST] api/users/add


2. User Details Update 
[Post]  api/users/update

3. Bank Account Create Request 
[Post] api/users/bank/reqaccount
⦁	Check if there already pending request

4. Account Recharge with Scratchcards 
[Post] api/users/bank/Recharge

#### 	Pre condition :

⦁ Account has to be activated by Admin

⦁ Scratchcard used by this user will be invalid for further use.

⦁	Transaction history table will be updated with this new transactions

5. Passport Apply 
[Post] api/users/passport/apply/type  
#### 	Pre conditions :
⦁ Sufficient balance with active account

⦁ Check if already request exists

⦁Balance will updated according to the passport type

6. Add Income Tax 
[Post] api/users/Tax/addincome 

⦁	Tax will calculated based on BD tax calculation algorithm and create a row in tax table with the taxable amount

⦁ Check if already exists or not

	
7.	Update Income Tax 

[Post] api/users/Tax/updateincome
- Can only update current year data 

8.	Pay Tax 

[Post] api/users/Tax/PayTax

⦁	Check if account balance > desirable paid amount
⦁	Tax Paying history will stored inside another table
⦁	Account Balance will be updated

9. User Academic Info 
[Get] api/user/academicinfo 

⦁	See Academic results that are updated by Education Admin

10. Job Application
 [Get] api/jobapplication/applv/{ id} 

⦁	Check if already application exists [job id & user id checked]

⦁	Check if sufficient(500) balance is available

⦁	Account Balance will be updated

## Admin Controller : 
1.	See All users [GET] api/login/users 
2.	Delete Users [GET] api/login/delete/{id} 
3.	See Specific User [GET] api/login/user/{id} 
4.	See All users Details [GET] api/users 
5.	Active Users [POST] api/user/active/fidl 
6.	Block User [POST] api/user/block/{id} 
7.	View Bank Account [GET] api/admin/BankAccount/accounts 
8.	Accept Bank account [GET] api/admin/BankAccount/AcceptAccount/{id} 
9.	Block Bank Account [GET] api/admin/BankAccount/BlockAccount/lidl  10.Delete Bank Account [GET] api/admin/BankAccount/delete/{id}
10. Generate recharge scratchcard [GET] api/admin/BankAccount/genratetoken - 10 scratchcard will generate with unique token worth 5000 taka on each 

11. View Passport Applications [GET] apitadmmipassporttapplications  13.View Passports [GET] api/admin/passports 

12. Accept Passport Application request [GET] api/admin/passport/Accept/{id} 

13. Block Passport [GET] api/admin/passport/Block/fidl  

14. Active Passport [GET] api/admin/passport/Active/fidl

15. CRUD User Acadmic Info

16. CRUD Job application

17. CRUD Job Circular

