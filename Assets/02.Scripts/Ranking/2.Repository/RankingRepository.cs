﻿using UnityEngine;
using System.Collections.Generic;   
public class RankingRepository : MonoBehaviour
{
    public List<RankingSaveData> Load()
    {
        // 데이터가 아직 없지만 ..
        // 개발 단계에서 데이터가 필요하다면.. Mocking 기법을 쓴다.
        // PlayerPrefs대신 '가짜 데이터 반환'
        // 이준엽 : "GTP가 모킹데이터 잘 만들어준다! 100개 만들어보자"
        return new List<RankingSaveData>()
        {   
            new RankingSaveData(9850, "user1@example.com", "Storm"),
new RankingSaveData(9700, "user2@example.com", "Galaxy"),
new RankingSaveData(9600, "user3@example.com", "Choco"),
new RankingSaveData(9580, "user4@example.com", "Beast"),
new RankingSaveData(9450, "user5@example.com", "MoonSwd"),
new RankingSaveData(9400, "user6@example.com", "IronAx"),
new RankingSaveData(9320, "user7@example.com", "FireFist"),
new RankingSaveData(9280, "user8@example.com", "Thunder"),
new RankingSaveData(9240, "user9@example.com", "Rainbow"),
new RankingSaveData(9190, "user10@example.com", "FrostDg"),
new RankingSaveData(9120, "user11@example.com", "NightGd"),
new RankingSaveData(9080, "user12@example.com", "NightPr"),
new RankingSaveData(9050, "user13@example.com", "MapleTr"),
new RankingSaveData(8990, "user14@example.com", "DarkPir"),
new RankingSaveData(8940, "user15@example.com", "SunsetH"),
new RankingSaveData(8900, "user16@example.com", "WindHro"),
new RankingSaveData(8850, "user17@example.com", "CalmBl"),
new RankingSaveData(8800, "user18@example.com", "ColdWill"),
new RankingSaveData(8750, "user19@example.com", "SilverW"),
new RankingSaveData(8700, "user20@example.com", "EarthPw"),
new RankingSaveData(8650, "user21@example.com", "BlackDr"),
new RankingSaveData(8600, "user22@example.com", "DawnLit"),
new RankingSaveData(8550, "user23@example.com", "BoltThd"),
new RankingSaveData(8500, "user24@example.com", "RedCrow"),
new RankingSaveData(8450, "user25@example.com", "EchoHro"),
new RankingSaveData(8400, "user26@example.com", "Crimson"),
new RankingSaveData(8350, "user27@example.com", "ShadTrk"),
new RankingSaveData(8300, "user28@example.com", "ShadowBl"),
new RankingSaveData(8250, "user29@example.com", "LightIn"),
new RankingSaveData(8200, "user30@example.com", "ThunderL"),
new RankingSaveData(8150, "user31@example.com", "GalaxyS"),
new RankingSaveData(8100, "user32@example.com", "GoldCat"),
new RankingSaveData(8050, "user33@example.com", "WhirlRg"),
new RankingSaveData(8000, "user34@example.com", "HellGrd"),
new RankingSaveData(7950, "user35@example.com", "StarGd"),
new RankingSaveData(7900, "user36@example.com", "WinterS"),
new RankingSaveData(7850, "user37@example.com", "RedShld"),
new RankingSaveData(7800, "user38@example.com", "SkyWalk"),
new RankingSaveData(7750, "user39@example.com", "DreamSw"),
new RankingSaveData(7700, "user40@example.com", "LightPt"),
new RankingSaveData(7650, "user41@example.com", "ShadEye"),
new RankingSaveData(7600, "user42@example.com", "IceStorm"),
new RankingSaveData(7550, "user43@example.com", "RedSun"),
new RankingSaveData(7500, "user44@example.com", "MoonRge"),
new RankingSaveData(7450, "user45@example.com", "MadDance"),
new RankingSaveData(7400, "user46@example.com", "UnderSl"),
new RankingSaveData(7350, "user47@example.com", "DarkRea"),
new RankingSaveData(7300, "user48@example.com", "Immortal"),
new RankingSaveData(7250, "user49@example.com", "Typhoon"),
new RankingSaveData(7200, "user50@example.com", "StormWr"),
new RankingSaveData(7150, "user51@example.com", "HermitS"),
new RankingSaveData(7100, "user52@example.com", "AbyssSw"),
new RankingSaveData(7050, "user53@example.com", "MeteorF"),
new RankingSaveData(7000, "user54@example.com", "DawnTrk"),
new RankingSaveData(6950, "user55@example.com", "ShadMrk"),
new RankingSaveData(6900, "user56@example.com", "IceSpear"),
new RankingSaveData(6850, "user57@example.com", "DarkEye"),
new RankingSaveData(6800, "user58@example.com", "WhiteFl"),
new RankingSaveData(6750, "user59@example.com", "JudgeF"),
new RankingSaveData(6700, "user60@example.com", "MadFlame"),
new RankingSaveData(6650, "user61@example.com", "CurseBl"),
new RankingSaveData(6600, "user62@example.com", "HolySana"),
new RankingSaveData(6550, "user63@example.com", "EarthSon"),
new RankingSaveData(6500, "user64@example.com", "WaveMst"),
new RankingSaveData(6450, "user65@example.com", "BlackFog"),
new RankingSaveData(6400, "user66@example.com", "ShineSh"),
new RankingSaveData(6350, "user67@example.com", "MistArc"),
new RankingSaveData(6300, "user68@example.com", "IronWar"),
new RankingSaveData(6250, "user69@example.com", "WindJmp"),
new RankingSaveData(6200, "user70@example.com", "QuickFt"),
new RankingSaveData(6150, "user71@example.com", "SnakeTth"),
new RankingSaveData(6100, "user72@example.com", "RedMist"),
new RankingSaveData(6050, "user73@example.com", "AngelSh"),
new RankingSaveData(6000, "user74@example.com", "BlackTy"),
new RankingSaveData(5950, "user75@example.com", "SeaLion"),
new RankingSaveData(5900, "user76@example.com", "HellGate"),
new RankingSaveData(5850, "user77@example.com", "FallenH"),
new RankingSaveData(5800, "user78@example.com", "RevengF"),
new RankingSaveData(5750, "user79@example.com", "EndRage"),
new RankingSaveData(5700, "user80@example.com", "PrdiseS"),
new RankingSaveData(5650, "user81@example.com", "GhostWr"),
new RankingSaveData(5600, "user82@example.com", "MagicRg"),
new RankingSaveData(5550, "user83@example.com", "CalmWve"),
new RankingSaveData(5500, "user84@example.com", "GodsWr"),
new RankingSaveData(5450, "user85@example.com", "FateTrk"),
new RankingSaveData(5400, "user86@example.com", "FrostSc"),
new RankingSaveData(5350, "user87@example.com", "SkyArrow"),
new RankingSaveData(5300, "user88@example.com", "JudgeEg"),
new RankingSaveData(5250, "user89@example.com", "MoonWar"),
new RankingSaveData(5200, "user90@example.com", "MemArrow"),
new RankingSaveData(5150, "user91@example.com", "DarkDoll"),
new RankingSaveData(5100, "user92@example.com", "WhiteKt"),
new RankingSaveData(5050, "user93@example.com", "RedMoon"),
new RankingSaveData(5000, "user94@example.com", "LightnSp"),
new RankingSaveData(4950, "user95@example.com", "SkyWatc"),
new RankingSaveData(4900, "user96@example.com", "SilverRe"),
new RankingSaveData(4850, "user97@example.com", "Formlss"),
new RankingSaveData(4800, "user98@example.com", "FateStar"),
new RankingSaveData(4750, "user99@example.com", "SorrowW"),
new RankingSaveData(4700, "user100@example.com", "LghtDark"),
new RankingSaveData(1813, "tester1@example.com", "CoolRab6"),
new RankingSaveData(2721, "tester2@example.com", "ShineTig"),
new RankingSaveData(2960, "tester3@example.com", "SweetHam"),
new RankingSaveData(2263, "tester4@example.com", "WarmRab7"),
new RankingSaveData(1552, "tester5@example.com", "CuteFox4"),
new RankingSaveData(2086, "tester6@example.com", "HappyCat"),
new RankingSaveData(2065, "tester7@example.com", "WarmHam"),
new RankingSaveData(1211, "tester8@example.com", "SpaceCat"),
new RankingSaveData(2139, "tester9@example.com", "ScaryLi5"),
new RankingSaveData(1469, "tester10@example.com", "SpaceRab"),
new RankingSaveData(2786, "tester11@example.com", "HappyFox"),
new RankingSaveData(2850, "tester12@example.com", "CuteRab5"),
new RankingSaveData(3100, "tester13@example.com", "CoolWol7"),
new RankingSaveData(3034, "tester14@example.com", "CoolFox5"),
new RankingSaveData(2446, "tester15@example.com", "ShineCat"),
new RankingSaveData(3175, "tester16@example.com", "WarmFox8"),
new RankingSaveData(1056, "tester17@example.com", "CuteBer6"),
new RankingSaveData(2492, "tester18@example.com", "HappyHam"),
new RankingSaveData(1527, "tester19@example.com", "MadFox34"),
new RankingSaveData(2710, "tester20@example.com", "SweetRab"),
new RankingSaveData(2869, "tester21@example.com", "HappyTig"),
new RankingSaveData(2825, "tester22@example.com", "HappyBer"),
new RankingSaveData(1045, "tester23@example.com", "QuietCat"),
new RankingSaveData(2503, "tester24@example.com", "HappyCat"),
new RankingSaveData(2992, "tester25@example.com", "ScaryBer"),
new RankingSaveData(2265, "tester26@example.com", "SweetCat"),
new RankingSaveData(2060, "tester27@example.com", "SpaceHam"),
new RankingSaveData(1108, "tester28@example.com", "WarmLi11"),
new RankingSaveData(1762, "tester29@example.com", "MadPan56"),
new RankingSaveData(1589, "tester30@example.com", "SpaceCat"),
new RankingSaveData(2546, "tester31@example.com", "CuteWol5"),
new RankingSaveData(2895, "tester32@example.com", "HappyFox"),
new RankingSaveData(3134, "tester33@example.com", "MadHam63"),
new RankingSaveData(1165, "tester34@example.com", "MadHam52"),
new RankingSaveData(3341, "tester35@example.com", "WarmLi75"),
new RankingSaveData(3130, "tester36@example.com", "ScaryWo1"),
new RankingSaveData(2464, "tester37@example.com", "CoolTig9"),
new RankingSaveData(1229, "tester38@example.com", "SweetLi5"),
new RankingSaveData(1641, "tester39@example.com", "CutePan4"),
new RankingSaveData(2241, "tester40@example.com", "QuietFx9"),
new RankingSaveData(1936, "tester41@example.com", "SpaceBer"),
new RankingSaveData(1521, "tester42@example.com", "ScaryFx7"),
new RankingSaveData(1584, "tester43@example.com", "WarmWol8"),
new RankingSaveData(1996, "tester44@example.com", "CuteBer1"),
new RankingSaveData(2161, "tester45@example.com", "SpaceEag"),
new RankingSaveData(1729, "tester46@example.com", "CuteBer3"),
new RankingSaveData(2398, "tester47@example.com", "MadTig73"),
new RankingSaveData(2360, "tester48@example.com", "WarmBer7"),
new RankingSaveData(1865, "tester49@example.com", "ShineHam"),
new RankingSaveData(3020, "tester50@example.com", "CoolTig4"),
new RankingSaveData(1697, "tester100@example.com", "HappyRab5")
            
        };
    }
}


public class RankingSaveData
{
    public int Score;
    public string Email;
    public string Nickname;

    public RankingSaveData(int score, string email, string nickName)
    {
        Score = score;
        Email = email;
        Nickname = nickName;
    }   
}