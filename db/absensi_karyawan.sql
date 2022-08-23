-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 23, 2022 at 04:37 PM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 7.4.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `absensi_karyawan`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_absensi`
--

CREATE TABLE `tbl_absensi` (
  `id` int(11) NOT NULL,
  `NIP` int(30) DEFAULT NULL,
  `tanggal_absen` date DEFAULT NULL,
  `waktu_datang` varchar(15) DEFAULT NULL,
  `waktu_pulang` varchar(15) DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `keterangan` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_absensi`
--

INSERT INTO `tbl_absensi` (`id`, `NIP`, `tanggal_absen`, `waktu_datang`, `waktu_pulang`, `status`, `keterangan`) VALUES
(88840, 111, '2022-08-20', '3:15:26 AM', '12:46:23 PM', 'Hadir', ''),
(88842, 111, '2022-08-01', '3:21:32 AM', '12:46:23 PM', 'Hadir', ''),
(88843, 111, '2022-08-15', '', '12:46:23 PM', 'Ijin', ''),
(88844, 4041, '2022-08-04', '', '', 'Sakit', 'sakit'),
(88845, 111, '2022-08-21', '12:35:04 PM', '12:46:23 PM', 'Hadir', ''),
(88846, 4041, '2022-08-21', '', '', 'Ijin', 'ambil rapot'),
(88847, 4040, '2022-08-21', '', '', 'Alpa', 'alpa'),
(88848, 4044, '2022-08-21', '1:04:53 PM', '', 'Hadir', ''),
(88849, 4045, '2022-08-21', '1:08:18 PM', '', 'Hadir', '');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_admin`
--

CREATE TABLE `tbl_admin` (
  `id` int(11) NOT NULL,
  `username` varchar(10) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_admin`
--

INSERT INTO `tbl_admin` (`id`, `username`, `password`) VALUES
(1, 'admin', 'admin'),
(3, '111', 'user'),
(4, '4041', 'user'),
(5, '4040', 'user'),
(6, '4042', 'user'),
(7, '4043', 'user'),
(8, '4044', 'user'),
(9, '4045', 'user');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_karyawan`
--

CREATE TABLE `tbl_karyawan` (
  `nip` int(11) DEFAULT NULL,
  `nama` varchar(255) DEFAULT NULL,
  `no_hp` varchar(255) DEFAULT NULL,
  `unit` varchar(255) DEFAULT NULL,
  `tanggal_lahir` date DEFAULT NULL,
  `jenis_kelamin` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_karyawan`
--

INSERT INTO `tbl_karyawan` (`nip`, `nama`, `no_hp`, `unit`, `tanggal_lahir`, `jenis_kelamin`) VALUES
(111, 'am jannah', '0812993899', 'marketing', '2000-02-02', 'Laki-Laki'),
(4042, 'bis', '0000001', 'perkap', '2020-02-04', 'Perempuan'),
(4043, 'aas', '08129388290', 'perkap', '2022-03-31', 'Laki-Laki'),
(4044, 'anis', '01288291', 'dept name', '2000-02-08', 'Perempuan'),
(4041, 'roy', '0812999201', 'sales', '1999-12-26', 'Laki-Laki'),
(4040, 'Hamad', '08288291', 'DMA', '1990-02-06', 'Laki-Laki'),
(4045, 'patrik o', '0812334529', 'perkap', '1999-11-18', 'Laki-Laki');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_laporan`
--

CREATE TABLE `tbl_laporan` (
  `nip` int(11) DEFAULT NULL,
  `nama` varchar(255) DEFAULT NULL,
  `hadir` varchar(5) DEFAULT NULL,
  `sakit` varchar(5) DEFAULT NULL,
  `ijin` varchar(5) DEFAULT NULL,
  `alpa` varchar(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_laporan`
--

INSERT INTO `tbl_laporan` (`nip`, `nama`, `hadir`, `sakit`, `ijin`, `alpa`) VALUES
(111, 'am jannah', '3', '0', '1', '0'),
(4041, 'roy', '0', '1', '1', '0'),
(4040, 'Hamad', '0', '0', '0', '1'),
(4044, 'anis', '1', '0', '0', '0'),
(4045, 'patrik o', '1', '0', '0', '0');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_absensi`
--
ALTER TABLE `tbl_absensi`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_absensi`
--
ALTER TABLE `tbl_absensi`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=88850;

--
-- AUTO_INCREMENT for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
