-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 22, 2019 at 03:06 PM
-- Server version: 5.6.21
-- PHP Version: 5.5.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `dbsecure`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblpassword`
--

CREATE TABLE IF NOT EXISTS `tblpassword` (
`id` int(11) NOT NULL,
  `User_Id` text NOT NULL,
  `Password` text NOT NULL,
  `Status` text NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblpassword`
--

INSERT INTO `tblpassword` (`id`, `User_Id`, `Password`, `Status`) VALUES
(1, 'iI14852487', '26270429', ' 13:56'),
(2, 'iI14852487', '42359746', ' 13:62'),
(3, 'iI14852487', '04128936', ' 13:66'),
(4, 'iI14852487', '00863326', ' 13:67'),
(5, 'iI14852487', '20609374', ' 13:69'),
(6, 'iI14852487', '46696355', ' 14:14');

-- --------------------------------------------------------

--
-- Table structure for table `tblusers`
--

CREATE TABLE IF NOT EXISTS `tblusers` (
`id` int(11) NOT NULL,
  `User_Id` text NOT NULL,
  `Name` text NOT NULL,
  `Gender` text NOT NULL,
  `Phone` text NOT NULL,
  `fp` longblob NOT NULL,
  `Dates` text NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblusers`
--

INSERT INTO `tblusers` (`id`, `User_Id`, `Name`, `Gender`, `Phone`, `fp`, `Dates`) VALUES
(1, 'iI14852487', 'Michael James', 'M', '08061304097', 0x00f87201c82ae3735cc0413709ab7170a6145592c2e13a4db951ac9126c2f56114ec5a9dbcb47bc0d103e26df82ae0d316984dfde3c4bd69c4b8e3d430f0ce7e2d365182f12e28b8ec3b273ffad5102ce825accb354d828292652cbc1e1b4fa2b1d8c8de2933a8ba6fe3526e72a9444351fb38c7f1bcc47bf172c40297f457cccf39fd21b18cad0169f4547944e7288f0449c6e0299d2a842cff4c5807e930f666f083e7fff7fef8b228a64e2038429dbbb4c82936320c1ec7768b9da197502cb0979a7aa10f9dc3cbfb1bc64adadbf8f4602ba80de451c1d6983629db421b67e2aa789f1cb8d06b0a33a08957032d69775199aa30fab89aeb017c39909e6d6435ed0e039c13e5c1f25da724e5b98448096713683400ac5d6ceaf818e309ec54bfac5247762679dbedcaaf0b75c081067980329099153c28606171e8853163fbdeae863d9a126b6601112760b40336a311cad849790c2136e403f76349461f4293f4ce90ff52b97968430ddafcc520d09fa5cff5e5536f00f82f01c82ae3735cc0413709ab71b0a3145592020ab490bb56bc5aef362d6587bc0c1fd0b5d5c8e761c7102a94e6cd5c0f0b71892c63df4007b0f546ac8d82f9b364b71e4dbe18baee503570ad1a59f009d99ca003129f81b7497cf1343b289e1637cb45ae94218116ddc19a7575024e6c265b1e73f89cfcb51b1a02a5c1d0b63ea6b452abefca225a517e1c1f00c69e0f9eb777dfeee1486f78543316dcff3434103393908c9a47d5a0b8bf9a4dc01239682ad732f90e81a2e4f2678600ee556ffbaa95701168f7f872eabdf0cf20669f510a89e78bb46ae297b72f2a518316e3c258960419962a0b3db85a5bca337c684119b7c1e9651ea8fbcb73c98fcc91d645eba687a29976d6ff11cdf4de045c1058d118a9e4a5ab1c2f3da7dbd7e6393ee8cc7525d096d54b9b351121af0df22d4e6f00f87201c82ae3735cc0413709ab71b0bc14559202c80867959b5eca44e7276be19ef2c08ce182211a0e68c26e11f5010f1a32b6dfd07c60cf14e98dc4e1c4b9c2fd8379e38eaa12fe049352a267764b53072c09ed4735fd3a2e90ffe5eda396dd98de3a881dec747a179566a26fe94b508797d4a6184220bd0dc4599c9a8dce7fd449012d234e3b9a3dfed862f3db93a682074e32c5662a1e909a11ff0e1c1043cbdafe9265a3582bcf66abb14771917778ab9256f7a88797bd7f3ee7e60f86c223d1bedbcbc2168bdb5357904adb8f43720827868a98f77073e6f53974847cd0a0fcd9ee266deeeaf2b0b252eece9dc45b28bb69fb1e99a846c9e15dad2e715a44534d438e92e848b15aa82c05b8ad560bda4cd8675be8fa3c88ccb5da3bdd484e6e11c7991854c6fd564b9dbc95f999291f6efa84a4193aa589ff44a446518cd827f9dc607e93eb1335fa6de9924ab1cee4046bf3f2885d60334bfeda8225524871f2ac193588b993fc0577c962bdff0d6e3b0e846f00e82601c82ae3735cc0413709ab7130ab14559295d0c67fab016f3c2882f2fc8d0f9dfee413910c59f32ea64f38f62fb43e8fee50049258a9e515b17a940aaa44163d6dcf256db686584247f5214ef4ca2136a582521dd09786f8a82adca72da3069179e025b08987263d6b4dba98c4328dafe0223321d5211404c057f985c78938f2ccd8f95409cf02795b4c2cb697a30be2470403cbbbd1df48c899605a2c9bbbc314febaac3f987eff242d816fbb8c4cf81be0bf4758f74ff557f9273bc4b50217526971b992bbfb395e6aaffa5b33d355725caba1a995b07820710ab8942bad68a4485b40b1c31ef0bc18d87e45b79042c2b22a8a5149609b22497e25c9d2cb368d33b74ac85d25329138de693cdeba612a41dbc3f96e1dc8ddbac80b6a7135053ea788624683ad6f00000000000000d0381c01ffffffff00000000d0381c01c071170110201701fc000006000000000000000000000000d0381c01ffffffff0000000004000000000000000000000004325701e0371c016c7517011020170135010006000000000000000000000000e0371c01ffffffff78335701e0371c019872170110201701fd000006000000000000000000000000e0371c01ffffffffc0335701e0371c01a472170110201701fe000006000000000000000000000000e0371c01ffffffffa8355701e0371c01b072170110201701ff000006000000000000000000000000e0371c01ffffffffa93e9a07e0371c01bc7217011020170100010006000000000000000000000000e0371c01ffffffff713f9a07, '2019-04-22'),
(2, 'cu77576484', 'John Godwin', 'M', '08040000000', 0x00f87e01c82ae3735cc0413709ab7130ba145592bb463a888e3fe95eef440c4816a40dbfd0e5a8542962221951f57259255a5a6ad02a61b979fd04f27114e248557d93f821a0629b882237ae486e7d89ab1146a964c02f56f605e37e841bc95ddf525e1f713252d7e3585cdbbf4e05193808fb64af801efed940419e08e44c099aa5eae0ee857b1e63a5e61edc9bf210f4dfe5f07b44894d9c634e027aa93f22365809e9effa3c907ef1de4f5065acb22ca7759ffec8722feab69d317419a98c40dd1e6e54f6ace5693706c1753a7af989d383075cd905edbef90e340445af6e0d7f265a30266ba68f20e84fca48778e5337d8a97dd2f47216ad1ac3a1921c8d4475ed99e275d90ffe9edd0090ca276cbc71c81d1ad8017c70b0a9eb89ad63ad092a18b48e4e4bad9056cf133934fbcae7e68c70e2daec643c9645c6dbe1d21ab86565c4f648fb56aa7add51e61d2bee11bd99327a476c3abd67d52b62c335e8338a7ec25ccd8030e1caf99af0a0fd93fa64aa2533cfb4185dbc266b93d9c95d54b26f00f87f01c82ae3735cc0413709ab7130b8145592b61220d7744c4e81768b0c7e7719ff3ad3039e85f63cfee04360e4b92967478c4c20a8c8b8ae9d7c58a59add4da2f214371e6e14a4335bc53680bb8cfb0419eccb2ced01d31b17b2a6b05eefdadbbb88132cacb20c98155746e5806ef89d24594c626f5be783a81d4e00d9d2c258bd43da6178ab25d9e737121486bdf62c687d7a5979320aa7fd7873ba2d29fce980aa1dd8c700ea9ee249c56a480a8df573e2f48201cca338338caa6c4ab07c63c62dfae13b13bddb41f02a89497c3e90657939d442601257f2ccc3ba2b5af4f1fbfb06f2ac0ce508d2b3303381112716522171d4cdcb0bc189fe8d34248cdd0d05df2584634dd9b5c8b31a1fe239fb46f00dc078cc56799ad30729c39cc80e20370f3dc225317bb792490fccb71023b9099d27b3e14bd3bf529607cb4183124dadc2d8c912cf4fb31e2856e41d9be06cbe653893fbd08da6c6f006c5dd426d7af699c3e7333638267be2e831f8e431d9ac7fc2e23b6af26413492cef89b8142f7a6f00f88101c82ae3735cc0413709ab7130b8145592c90f32c86040c17afbe4117abe467f9a2c72a1a24223b8b64dae2a6dfa93c762da2823eac075025c35b0c7a6aed9e388139c7a4024604f32e514b9a812b76a6e4c7083b3a828f63dae12731962efba3e3179d6429e5ffa923af9d0225066054862a81f7704065639a5ba7250a70920a4f85124781a6e08676b097225f4f05253be655386f3fdbaeeb8744f5bf04decd9f99ce7d2e2e7b6cf9b169aa61cafb546ab01edaa76a954198b0821750164d229a19fcc622c94176a165e41a697bce8c7498b92479302cd7090a5dea191baa2c50442513aa6e99a9e91751891be64fa4c009b31168779ca9b0a0161091eee35ef532b5666a93f7e1bf5646bd7a2742724cc40ed754c6ccac83a615d070ad0d57d2afa88587fa285435283d0d55d94a8eded46bf9fd465e1215f6ca046b9ce75e2c0d8c110c8325356fbd54ba403de2e4708db5f375b61667a2ef51e1aa84333ef09097bc2a8f883f20a34dc12d7259c49a2e8dbfa4a1621f89229cc228cef005a516f00e87f01c82ae3735cc0413709ab71b0ba14559297877e58fe8d89e48a1051729d5c8be264ac578f175eb151025c6bf8de676d208d4323d1e7d1b935d608a2843cddf7a5ee36cc692f5f65cf47709ad8613aaef3b0fe08b9bf8f3572cf30a28114195407a4173a3466b27bc9cbf828cff318ae582c8f8a8ffec21e1b045b351ad9ed270c467a3950cca9c130c18a8a289f17c06eaeeb88165723d0579eb4c6341bafda56610cd58ec5db9d18f4149f977e7bf136975d7a426cc9f915332e51b1201c2ffe59737e531c7257f106204a496f3385573690038bae35b9c62c162107cff1003091e7682c0ba596d02c330c930d69329fa5b2e5d2042ac7b06cf0933cb0fcf93d51ea6be77d51699ad743aab5678feb21190b9a8d0ae9bc60273e60d844260803d7b3dcd5dbb294b60ecebad3065f855ba4787ecc5b9a47a707ffb7a5a35e51ddbef79f627dfe52c7a79f5244c757242f2a607543a7d7e1e5ab0ceff3e7b796e9948044753b3e4ae14d0d4322a81b141482c381557867f27b703f8cec99fc276f9df802949df802949df802a09df802a09df802ec9df802ec9df802f89df802f89df802182e24010d00000d88130d00a8ea1a0170c82201000000000000000000000000000000000000000000000000, '2019-04-22');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblpassword`
--
ALTER TABLE `tblpassword`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tblusers`
--
ALTER TABLE `tblusers`
 ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tblpassword`
--
ALTER TABLE `tblpassword`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `tblusers`
--
ALTER TABLE `tblusers`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;