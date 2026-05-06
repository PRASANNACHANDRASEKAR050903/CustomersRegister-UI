CREATE DATABASE IF NOT EXISTS Customers;
USE Customers;

CREATE TABLE IF NOT EXISTS Customers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(100),
    LastName VARCHAR(100),
    Email VARCHAR(100),
    DateOfBirth DATE,
    Age INT,
    Gender VARCHAR(10)
);