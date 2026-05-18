-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 18, 2026 at 01:00 PM
-- Server version: 9.1.0
-- PHP Version: 8.3.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `onlinequizsystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;
CREATE TABLE IF NOT EXISTS `questions` (
  `id` int NOT NULL AUTO_INCREMENT,
  `quiz_id` int NOT NULL,
  `question_text` text NOT NULL,
  `option_a` varchar(200) NOT NULL,
  `option_b` varchar(200) NOT NULL,
  `option_c` varchar(200) NOT NULL,
  `option_d` varchar(200) NOT NULL,
  `correct_option` char(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_quiz` (`quiz_id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`id`, `quiz_id`, `question_text`, `option_a`, `option_b`, `option_c`, `option_d`, `correct_option`) VALUES
(12, 14, 'Which SQL command is used to retrieve data from a table?', 'UPDATE', 'INSERT', 'SELECT', 'DELETE', '3'),
(13, 14, 'Where is session data stored in PHP?', 'On the user\'s browser', 'In the URL', 'On the server', 'In a cookie file', '3'),
(14, 14, 'What does this code do?\r\nfilter_var($email, FILTER_VALIDATE_EMAIL);', 'Sends an email', 'Sanitizes email', 'Validates if email is in correct format', 'Converts email to string', '3'),
(19, 19, 'What does CPU stand for?', 'Central Processing Unit', 'Computer Primary Unit', 'Central Peripheral Unit', 'Control Processing Unit', '1'),
(20, 19, 'Which of the following is an input device?', 'Monitor', 'Keyboard', 'Printer', 'Speaker', '2');

-- --------------------------------------------------------

--
-- Table structure for table `quizzes`
--

DROP TABLE IF EXISTS `quizzes`;
CREATE TABLE IF NOT EXISTS `quizzes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `quiz_title` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `date` date NOT NULL,
  `duration` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `quizzes`
--

INSERT INTO `quizzes` (`id`, `quiz_title`, `date`, `duration`) VALUES
(14, 'Web Programming', '0000-00-00', 15),
(19, 'Introduction to Computer System', '0000-00-00', 10),
(22, 'Visual Application', '0000-00-00', 10),
(26, 'GK', '0000-00-00', 10);

-- --------------------------------------------------------

--
-- Table structure for table `results`
--

DROP TABLE IF EXISTS `results`;
CREATE TABLE IF NOT EXISTS `results` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(100) NOT NULL,
  `quiz_id` int NOT NULL,
  `score` int NOT NULL,
  `total` int NOT NULL,
  `date_time` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `results`
--

INSERT INTO `results` (`id`, `username`, `quiz_id`, `score`, `total`, `date_time`) VALUES
(12, 'Afna', 13, 3, 3, '2025-10-30 21:18:21'),
(14, 'Afna', 14, 2, 3, '2025-10-31 21:23:08'),
(15, 'Afna', 17, 2, 2, '2025-11-02 12:18:48'),
(16, 'Afna', 19, 2, 2, '2025-11-02 12:44:32'),
(17, 'Afna', 19, 1, 2, '2025-11-02 18:05:14'),
(18, 'Mohammed', 19, 1, 2, '2025-11-16 07:43:20'),
(19, 'Mohammed', 14, 2, 3, '2025-11-16 07:44:12'),
(20, 'Dhoni', 19, 2, 2, '2025-11-16 07:45:13'),
(21, 'Dhoni', 14, 3, 3, '2025-11-16 07:45:59'),
(24, 'Dhoni', 19, 1, 2, '2025-11-16 19:44:59');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `role` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `role`) VALUES
(10, 'Afna', '10', 'Student'),
(26, 'Mohammed', '12345', 'Student'),
(27, 'Dhoni', '1234', 'Student'),
(30, 'Sadeeka', '1234', 'Admin');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `fk_quiz` FOREIGN KEY (`quiz_id`) REFERENCES `quizzes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
