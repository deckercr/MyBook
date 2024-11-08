-- Create the database
CREATE DATABASE CollegeDB;
GO

USE CollegeDB;
GO

-- Create Students table
CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1000,1),
    StudentName NVARCHAR(100) NOT NULL
);

-- Create Courses table
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY(100,1),
    CourseTitle NVARCHAR(100) NOT NULL,
    SemesterOffered NVARCHAR(20) NOT NULL
);

-- Create StudentCourses junction table for many-to-many relationship
CREATE TABLE StudentCourses (
    StudentID INT,
    CourseID INT,
    EnrollmentStatus NVARCHAR(20) NOT NULL CHECK (EnrollmentStatus IN ('Completed', 'InProgress')),
    EnrollmentDate DATE DEFAULT GETDATE(),
    CONSTRAINT PK_StudentCourses PRIMARY KEY (StudentID, CourseID),
    CONSTRAINT FK_StudentCourses_Students FOREIGN KEY (StudentID) 
        REFERENCES Students(StudentID) ON DELETE CASCADE,
    CONSTRAINT FK_StudentCourses_Courses FOREIGN KEY (CourseID) 
        REFERENCES Courses(CourseID) ON DELETE CASCADE
);

-- Create indexes for better query performance
CREATE INDEX IX_Students_Name ON Students(StudentName);
CREATE INDEX IX_Courses_Title ON Courses(CourseTitle);

-- Insert sample data
INSERT INTO Students (StudentName) VALUES 
    ('John Doe'),
    ('Jane Smith'),
    ('Bob Johnson');

INSERT INTO Courses (CourseTitle, SemesterOffered) VALUES 
    ('Introduction to Programming', 'Fall 2024'),
    ('Database Systems', 'Spring 2024'),
    ('Web Development', 'Fall 2024');

INSERT INTO StudentCourses (StudentID, CourseID, EnrollmentStatus) VALUES 
    (1000, 100, 'InProgress'),
    (1000, 101, 'Completed'),
    (1001, 100, 'InProgress');