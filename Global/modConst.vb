Module modConst

    Public DEFAULT_DATE As Date = New Date(1900, 1, 1)

    Public Enum Enum_SecurityID
        eRead = 1
        eTrader = 2
        eAdmin = 3
    End Enum

    Public Enum Enum_TimeFrame
        eDay = 0
        eWeek = 1
        eMonth = 2
        eYear = 3
        e5Year = 4
    End Enum

    Public Enum Enum_Sectors
        eEnergy = 0
        eMaterials = 1
        eIndustrials = 2
        eConsumerDiscretionary = 3
        eConsumerStaples = 4
        eHealthCare = 5
        eFinancials = 6
        eInformationTechnology = 7
        eTelecommunicationServices = 8
        eUtilities = 9
        eRealEstate = 10
    End Enum

    Public Enum ENUM_IOrder
        eOrderID = 0
        eClientOrderID = 1
        eCreatedAtUTC = 2
        eUpdatedAtUTC = 3
        eSubmittedAtUTC = 4
        eFilledAtUTC = 5
        eExpiredAtUTC = 6
        eCancelledAtUTC = 7
        eFailedAtUTC = 8
        eReplacedAtUTC = 9
        eAssetID = 10
        eSymbol = 11
        eAssetClass = 12
        eNotional = 13
        eQuantity = 14
        eFilledQuantity = 15
        eIntegerQuantity = 16
        eIntegerFilledQuantity = 17
        eOrderType = 18
        eOrderClass = 19
        eOrderSide = 20
        eTimeInForce = 21
        eLimitPrice = 22
        eStopPrice = 23
        eTrailOffsetInDollars = 24
        eTrailOffsetInPercent = 25
        eHighWaterMark = 26
        eAverageFillPrice = 27
        eOrderStatus = 28
        eReplacedByOrderID = 29
        eReplacesOrderID = 30
        eLegs = 31
    End Enum

    Public Enum ENUM_SBPane
        eInfo = 0
        eProgressBar = 1
        eUser = 2
        ePermission = 3
        eRunMode = 4
        eServiceStatus = 5
    End Enum

    Public Enum ENUM_RunMode
        eDebug = 1
        eThreaded = 2
    End Enum

    Public Enum ENUM_ReportID
        eJobOutcome = 1
        eTop50Assets = 2
    End Enum

    Public Enum ENUM_FileType
        eNone = 0
        eText = 1
        eSQL = 2
        eExcel = 3
        eExcelx = 4
        eKML = 5
        eExcelm = 6
        eWord = 7
        eCSV = 8
    End Enum

    Public Enum ENUM_JobStatusID
        eInQueue = 1
        eInProgress = 2
        eCompleted = 3
        eFailed = 4
        eCancelled = 5
    End Enum

    Public Enum ENUM_JobTypeID
        eRefreshAssetData = 1
        eRefreshAssetScore = 2
        ePaperTrade = 3
        eLiveTrade = 4
        eDataCleanup = 5
        eDailyJob = 6
    End Enum

    Public Enum ENUM_DividendType
        eCD = 1
        eSC = 2
        eLT = 3
        eST = 4
    End Enum

End Module
