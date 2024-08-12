E-COMMERCE WEB API
This project is a digital products platform developed as part of the Patika.dev & Papara .Net Bootcamp. The platform allows users to purchase digital products and product licenses through three channels: Android, iOS, and Web. Users can earn loyalty points with each purchase, which can be redeemed for discounts on future purchases. The platform also supports a coupon system, enabling users to make purchases at reduced prices.

Features
User Operations
User Roles: Two user roles are supported—normal users and admin users.
Registration: Users can register and set their username and password.
Login: Users can log in and start shopping.
Digital Wallet: Users have a digital wallet for instant payment transactions.
Shopping: Users can add all desired products to a cart.
Admin Operations: Admin users can manage digital products, categories, coupons, and users.
Product Operations
Product Management: Admin users can add, update, and delete products, and set prices.
Stock Management: Manage stock information and product status.
Category Management: Products can belong to multiple categories with a many-to-many relationship.
Loyalty Points: Products have a points system where users earn points based on the purchase price, up to a maximum limit.
Coupon System
Coupon Management: Admins can create and distribute unique coupon codes to users.
Coupon Usage: Users can apply coupons during checkout to reduce the total amount.
Point and Coupon Combination: Coupons are applied first, followed by points deduction.
Reporting
Product Details: Detailed information about products in the cart is available.
Database Models
User: Contains user information, role, status, wallet balance, and points balance.
Category: Includes category name, URL, and tags.
Product: Includes category, name, features, description, active status, and point percentage.
Product-Category Map: Many-to-many relationship between products and categories.
Product-Cart Map: Many-to-many relationship between products and carts
Tech Stack
Database: MSSQL
Authentication: JWT Token
ORM: Entity Framework with Repository and Unit of Work pattern
Documentation: Swagger

Design and Coding Standards
Meaningful variable and method names
Short and purpose-driven classes and methods
Low complexity with no deep nesting of if statements
No repeated code segments
Defensive validation in REST API methods
Consistent coding standards throughout the project
Dependency Injection for object dependencies
Minimal class dependencies using interfaces and abstractions
Adherence to SOLID principles, especially the Open-Closed principle
