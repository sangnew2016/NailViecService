var tempService = (function () {

    return {
        getDataTempForShops: getDataTempForShops,
        getDataTempForJobs: getDataTempForJobs
    };

    function getDataTempForJobs() {
        return {
            "draw": 1,
            "recordsTotal": 57,
            "recordsFiltered": 57,
            "data": [
              {
                  "DT_RowId": "row_5",
                  "first_name": "Airi",
                  "last_name": "Satou",
                  "position": "Accountant",
                  "office": "Tokyo",
                  "start_date": "28th Nov 08",
                  "salary": "$162,700"
              },
              {
                  "DT_RowId": "row_25",
                  "first_name": "Angelica",
                  "last_name": "Ramos",
                  "position": "Chief Executive Officer (CEO)",
                  "office": "London",
                  "start_date": "9th Oct 09",
                  "salary": "$1,200,000"
              },
              {
                  "DT_RowId": "row_3",
                  "first_name": "Ashton",
                  "last_name": "Cox",
                  "position": "Junior Technical Author",
                  "office": "San Francisco",
                  "start_date": "12th Jan 09",
                  "salary": "$86,000"
              },
              {
                  "DT_RowId": "row_19",
                  "first_name": "Bradley",
                  "last_name": "Greer",
                  "position": "Software Engineer",
                  "office": "London",
                  "start_date": "13th Oct 12",
                  "salary": "$132,000"
              },
              {
                  "DT_RowId": "row_28",
                  "first_name": "Brenden",
                  "last_name": "Wagner",
                  "position": "Software Engineer",
                  "office": "San Francisco",
                  "start_date": "7th Jun 11",
                  "salary": "$206,850"
              },
              {
                  "DT_RowId": "row_6",
                  "first_name": "Brielle",
                  "last_name": "Williamson",
                  "position": "Integration Specialist",
                  "office": "New York",
                  "start_date": "2nd Dec 12",
                  "salary": "$372,000"
              },
              {
                  "DT_RowId": "row_43",
                  "first_name": "Bruno",
                  "last_name": "Nash",
                  "position": "Software Engineer",
                  "office": "London",
                  "start_date": "3rd May 11",
                  "salary": "$163,500"
              },
              {
                  "DT_RowId": "row_23",
                  "first_name": "Caesar",
                  "last_name": "Vance",
                  "position": "Pre-Sales Support",
                  "office": "New York",
                  "start_date": "12th Dec 11",
                  "salary": "$106,450"
              },
              {
                  "DT_RowId": "row_51",
                  "first_name": "Cara",
                  "last_name": "Stevens",
                  "position": "Sales Assistant",
                  "office": "New York",
                  "start_date": "6th Dec 11",
                  "salary": "$145,600"
              },
              {
                  "DT_RowId": "row_4",
                  "first_name": "Cedric",
                  "last_name": "Kelly",
                  "position": "Senior Javascript Developer",
                  "office": "Edinburgh",
                  "start_date": "29th Mar 12",
                  "salary": "$433,060"
              }
            ]
        };
    }

    function getDataTempForShops() {
        var dataSet = [
                ["Tiger Nixon", "System Architect", "Edinburgh", "5421", "2011/04/25", "$320,800"],
                ["Garrett Winters", "Accountant", "Tokyo", "8422", "2011/07/25", "$170,750"],
                ["Ashton Cox", "Junior Technical Author", "San Francisco", "1562", "2009/01/12", "$86,000"],
                ["Cedric Kelly", "Senior Javascript Developer", "Edinburgh", "6224", "2012/03/29", "$433,060"],
                ["Airi Satou", "Accountant", "Tokyo", "5407", "2008/11/28", "$162,700"],
                ["Brielle Williamson", "Integration Specialist", "New York", "4804", "2012/12/02", "$372,000"],
                ["Herrod Chandler", "Sales Assistant", "San Francisco", "9608", "2012/08/06", "$137,500"],
                ["Rhona Davidson", "Integration Specialist", "Tokyo", "6200", "2010/10/14", "$327,900"],
                ["Colleen Hurst", "Javascript Developer", "San Francisco", "2360", "2009/09/15", "$205,500"],
                ["Sonya Frost", "Software Engineer", "Edinburgh", "1667", "2008/12/13", "$103,600"],
                ["Jena Gaines", "Office Manager", "London", "3814", "2008/12/19", "$90,560"],
                ["Quinn Flynn", "Support Lead", "Edinburgh", "9497", "2013/03/03", "$342,000"],
                ["Charde Marshall", "Regional Director", "San Francisco", "6741", "2008/10/16", "$470,600"],
                ["Haley Kennedy", "Senior Marketing Designer", "London", "3597", "2012/12/18", "$313,500"],
                ["Tatyana Fitzpatrick", "Regional Director", "London", "1965", "2010/03/17", "$385,750"],
                ["Michael Silva", "Marketing Designer", "London", "1581", "2012/11/27", "$198,500"],
                ["Paul Byrd", "Chief Financial Officer (CFO)", "New York", "3059", "2010/06/09", "$725,000"],
                ["Gloria Little", "Systems Administrator", "New York", "1721", "2009/04/10", "$237,500"],
                ["Bradley Greer", "Software Engineer", "London", "2558", "2012/10/13", "$132,000"],
                ["Dai Rios", "Personnel Lead", "Edinburgh", "2290", "2012/09/26", "$217,500"],
                ["Jenette Caldwell", "Development Lead", "New York", "1937", "2011/09/03", "$345,000"],
                ["Yuri Berry", "Chief Marketing Officer (CMO)", "New York", "6154", "2009/06/25", "$675,000"],
                ["Caesar Vance", "Pre-Sales Support", "New York", "8330", "2011/12/12", "$106,450"],
                ["Doris Wilder", "Sales Assistant", "Sidney", "3023", "2010/09/20", "$85,600"],
                ["Angelica Ramos", "Chief Executive Officer (CEO)", "London", "5797", "2009/10/09", "$1,200,000"],
                ["Gavin Joyce", "Developer", "Edinburgh", "8822", "2010/12/22", "$92,575"],
                ["Jennifer Chang", "Regional Director", "Singapore", "9239", "2010/11/14", "$357,650"],
                ["Brenden Wagner", "Software Engineer", "San Francisco", "1314", "2011/06/07", "$206,850"],
                ["Fiona Green", "Chief Operating Officer (COO)", "San Francisco", "2947", "2010/03/11", "$850,000"],
                ["Shou Itou", "Regional Marketing", "Tokyo", "8899", "2011/08/14", "$163,000"],
                ["Michelle House", "Integration Specialist", "Sidney", "2769", "2011/06/02", "$95,400"],
                ["Suki Burks", "Developer", "London", "6832", "2009/10/22", "$114,500"],
                ["Prescott Bartlett", "Technical Author", "London", "3606", "2011/05/07", "$145,000"],
                ["Gavin Cortez", "Team Leader", "San Francisco", "2860", "2008/10/26", "$235,500"],
                ["Martena Mccray", "Post-Sales support", "Edinburgh", "8240", "2011/03/09", "$324,050"],
                ["Unity Butler", "Marketing Designer", "San Francisco", "5384", "2009/12/09", "$85,675"]
        ];


            var data = [
              {
                  "name": "Tiger Nixon",
                  "position": "System Architect",
                  "salary": "$320,800",
                  "start_date": "2011/04/25",
                  "office": "Edinburgh",
                  "extn": "5421"
              },
              {
                  "name": "Garrett Winters",
                  "position": "Accountant",
                  "salary": "$170,750",
                  "start_date": "2011/07/25",
                  "office": "Tokyo",
                  "extn": "8422"
              },
              {
                  "name": "Ashton Cox",
                  "position": "Junior Technical Author",
                  "salary": "$86,000",
                  "start_date": "2009/01/12",
                  "office": "San Francisco",
                  "extn": "1562"
              },
              {
                  "name": "Cedric Kelly",
                  "position": "Senior Javascript Developer",
                  "salary": "$433,060",
                  "start_date": "2012/03/29",
                  "office": "Edinburgh",
                  "extn": "6224"
              },
              {
                  "name": "Airi Satou",
                  "position": "Accountant",
                  "salary": "$162,700",
                  "start_date": "2008/11/28",
                  "office": "Tokyo",
                  "extn": "5407"
              },
              {
                  "name": "Brielle Williamson",
                  "position": "Integration Specialist",
                  "salary": "$372,000",
                  "start_date": "2012/12/02",
                  "office": "New York",
                  "extn": "4804"
              },
              {
                  "name": "Herrod Chandler",
                  "position": "Sales Assistant",
                  "salary": "$137,500",
                  "start_date": "2012/08/06",
                  "office": "San Francisco",
                  "extn": "9608"
              },
              {
                  "name": "Rhona Davidson",
                  "position": "Integration Specialist",
                  "salary": "$327,900",
                  "start_date": "2010/10/14",
                  "office": "Tokyo",
                  "extn": "6200"
              },
              {
                  "name": "Colleen Hurst",
                  "position": "Javascript Developer",
                  "salary": "$205,500",
                  "start_date": "2009/09/15",
                  "office": "San Francisco",
                  "extn": "2360"
              },
              {
                  "name": "Sonya Frost",
                  "position": "Software Engineer",
                  "salary": "$103,600",
                  "start_date": "2008/12/13",
                  "office": "Edinburgh",
                  "extn": "1667"
              },
              {
                  "name": "Jena Gaines",
                  "position": "Office Manager",
                  "salary": "$90,560",
                  "start_date": "2008/12/19",
                  "office": "London",
                  "extn": "3814"
              },
              {
                  "name": "Quinn Flynn",
                  "position": "Support Lead",
                  "salary": "$342,000",
                  "start_date": "2013/03/03",
                  "office": "Edinburgh",
                  "extn": "9497"
              },
              {
                  "name": "Charde Marshall",
                  "position": "Regional Director",
                  "salary": "$470,600",
                  "start_date": "2008/10/16",
                  "office": "San Francisco",
                  "extn": "6741"
              },
              {
                  "name": "Haley Kennedy",
                  "position": "Senior Marketing Designer",
                  "salary": "$313,500",
                  "start_date": "2012/12/18",
                  "office": "London",
                  "extn": "3597"
              },
              {
                  "name": "Tatyana Fitzpatrick",
                  "position": "Regional Director",
                  "salary": "$385,750",
                  "start_date": "2010/03/17",
                  "office": "London",
                  "extn": "1965"
              },
              {
                  "name": "Michael Silva",
                  "position": "Marketing Designer",
                  "salary": "$198,500",
                  "start_date": "2012/11/27",
                  "office": "London",
                  "extn": "1581"
              },
              {
                  "name": "Paul Byrd",
                  "position": "Chief Financial Officer (CFO)",
                  "salary": "$725,000",
                  "start_date": "2010/06/09",
                  "office": "New York",
                  "extn": "3059"
              },
              {
                  "name": "Gloria Little",
                  "position": "Systems Administrator",
                  "salary": "$237,500",
                  "start_date": "2009/04/10",
                  "office": "New York",
                  "extn": "1721"
              },
              {
                  "name": "Bradley Greer",
                  "position": "Software Engineer",
                  "salary": "$132,000",
                  "start_date": "2012/10/13",
                  "office": "London",
                  "extn": "2558"
              },
              {
                  "name": "Dai Rios",
                  "position": "Personnel Lead",
                  "salary": "$217,500",
                  "start_date": "2012/09/26",
                  "office": "Edinburgh",
                  "extn": "2290"
              },
              {
                  "name": "Jenette Caldwell",
                  "position": "Development Lead",
                  "salary": "$345,000",
                  "start_date": "2011/09/03",
                  "office": "New York",
                  "extn": "1937"
              },
              {
                  "name": "Yuri Berry",
                  "position": "Chief Marketing Officer (CMO)",
                  "salary": "$675,000",
                  "start_date": "2009/06/25",
                  "office": "New York",
                  "extn": "6154"
              },
              {
                  "name": "Caesar Vance",
                  "position": "Pre-Sales Support",
                  "salary": "$106,450",
                  "start_date": "2011/12/12",
                  "office": "New York",
                  "extn": "8330"
              },
              {
                  "name": "Doris Wilder",
                  "position": "Sales Assistant",
                  "salary": "$85,600",
                  "start_date": "2010/09/20",
                  "office": "Sidney",
                  "extn": "3023"
              },
              {
                  "name": "Angelica Ramos",
                  "position": "Chief Executive Officer (CEO)",
                  "salary": "$1,200,000",
                  "start_date": "2009/10/09",
                  "office": "London",
                  "extn": "5797"
              },
              {
                  "name": "Gavin Joyce",
                  "position": "Developer",
                  "salary": "$92,575",
                  "start_date": "2010/12/22",
                  "office": "Edinburgh",
                  "extn": "8822"
              },
              {
                  "name": "Jennifer Chang",
                  "position": "Regional Director",
                  "salary": "$357,650",
                  "start_date": "2010/11/14",
                  "office": "Singapore",
                  "extn": "9239"
              },
              {
                  "name": "Brenden Wagner",
                  "position": "Software Engineer",
                  "salary": "$206,850",
                  "start_date": "2011/06/07",
                  "office": "San Francisco",
                  "extn": "1314"
              },
              {
                  "name": "Fiona Green",
                  "position": "Chief Operating Officer (COO)",
                  "salary": "$850,000",
                  "start_date": "2010/03/11",
                  "office": "San Francisco",
                  "extn": "2947"
              },
              {
                  "name": "Shou Itou",
                  "position": "Regional Marketing",
                  "salary": "$163,000",
                  "start_date": "2011/08/14",
                  "office": "Tokyo",
                  "extn": "8899"
              },
              {
                  "name": "Michelle House",
                  "position": "Integration Specialist",
                  "salary": "$95,400",
                  "start_date": "2011/06/02",
                  "office": "Sidney",
                  "extn": "2769"
              },
              {
                  "name": "Suki Burks",
                  "position": "Developer",
                  "salary": "$114,500",
                  "start_date": "2009/10/22",
                  "office": "London",
                  "extn": "6832"
              },
              {
                  "name": "Prescott Bartlett",
                  "position": "Technical Author",
                  "salary": "$145,000",
                  "start_date": "2011/05/07",
                  "office": "London",
                  "extn": "3606"
              },
              {
                  "name": "Gavin Cortez",
                  "position": "Team Leader",
                  "salary": "$235,500",
                  "start_date": "2008/10/26",
                  "office": "San Francisco",
                  "extn": "2860"
              },
              {
                  "name": "Martena Mccray",
                  "position": "Post-Sales support",
                  "salary": "$324,050",
                  "start_date": "2011/03/09",
                  "office": "Edinburgh",
                  "extn": "8240"
              },
              {
                  "name": "Unity Butler",
                  "position": "Marketing Designer",
                  "salary": "$85,675",
                  "start_date": "2009/12/09",
                  "office": "San Francisco",
                  "extn": "5384"
              },
              {
                  "name": "Howard Hatfield",
                  "position": "Office Manager",
                  "salary": "$164,500",
                  "start_date": "2008/12/16",
                  "office": "San Francisco",
                  "extn": "7031"
              },
              {
                  "name": "Hope Fuentes",
                  "position": "Secretary",
                  "salary": "$109,850",
                  "start_date": "2010/02/12",
                  "office": "San Francisco",
                  "extn": "6318"
              },
              {
                  "name": "Vivian Harrell",
                  "position": "Financial Controller",
                  "salary": "$452,500",
                  "start_date": "2009/02/14",
                  "office": "San Francisco",
                  "extn": "9422"
              },
              {
                  "name": "Timothy Mooney",
                  "position": "Office Manager",
                  "salary": "$136,200",
                  "start_date": "2008/12/11",
                  "office": "London",
                  "extn": "7580"
              },
              {
                  "name": "Jackson Bradshaw",
                  "position": "Director",
                  "salary": "$645,750",
                  "start_date": "2008/09/26",
                  "office": "New York",
                  "extn": "1042"
              },
              {
                  "name": "Olivia Liang",
                  "position": "Support Engineer",
                  "salary": "$234,500",
                  "start_date": "2011/02/03",
                  "office": "Singapore",
                  "extn": "2120"
              },
              {
                  "name": "Bruno Nash",
                  "position": "Software Engineer",
                  "salary": "$163,500",
                  "start_date": "2011/05/03",
                  "office": "London",
                  "extn": "6222"
              },
              {
                  "name": "Sakura Yamamoto",
                  "position": "Support Engineer",
                  "salary": "$139,575",
                  "start_date": "2009/08/19",
                  "office": "Tokyo",
                  "extn": "9383"
              },
              {
                  "name": "Thor Walton",
                  "position": "Developer",
                  "salary": "$98,540",
                  "start_date": "2013/08/11",
                  "office": "New York",
                  "extn": "8327"
              },
              {
                  "name": "Finn Camacho",
                  "position": "Support Engineer",
                  "salary": "$87,500",
                  "start_date": "2009/07/07",
                  "office": "San Francisco",
                  "extn": "2927"
              },
              {
                  "name": "Serge Baldwin",
                  "position": "Data Coordinator",
                  "salary": "$138,575",
                  "start_date": "2012/04/09",
                  "office": "Singapore",
                  "extn": "8352"
              },
              {
                  "name": "Zenaida Frank",
                  "position": "Software Engineer",
                  "salary": "$125,250",
                  "start_date": "2010/01/04",
                  "office": "New York",
                  "extn": "7439"
              },
              {
                  "name": "Zorita Serrano",
                  "position": "Software Engineer",
                  "salary": "$115,000",
                  "start_date": "2012/06/01",
                  "office": "San Francisco",
                  "extn": "4389"
              },
              {
                  "name": "Jennifer Acosta",
                  "position": "Junior Javascript Developer",
                  "salary": "$75,650",
                  "start_date": "2013/02/01",
                  "office": "Edinburgh",
                  "extn": "3431"
              },
              {
                  "name": "Cara Stevens",
                  "position": "Sales Assistant",
                  "salary": "$145,600",
                  "start_date": "2011/12/06",
                  "office": "New York",
                  "extn": "3990"
              },
              {
                  "name": "Hermione Butler",
                  "position": "Regional Director",
                  "salary": "$356,250",
                  "start_date": "2011/03/21",
                  "office": "London",
                  "extn": "1016"
              },
              {
                  "name": "Lael Greer",
                  "position": "Systems Administrator",
                  "salary": "$103,500",
                  "start_date": "2009/02/27",
                  "office": "London",
                  "extn": "6733"
              },
              {
                  "name": "Jonas Alexander",
                  "position": "Developer",
                  "salary": "$86,500",
                  "start_date": "2010/07/14",
                  "office": "San Francisco",
                  "extn": "8196"
              },
              {
                  "name": "Shad Decker",
                  "position": "Regional Director",
                  "salary": "$183,000",
                  "start_date": "2008/11/13",
                  "office": "Edinburgh",
                  "extn": "6373"
              },
              {
                  "name": "Michael Bruce",
                  "position": "Javascript Developer",
                  "salary": "$183,000",
                  "start_date": "2011/06/27",
                  "office": "Singapore",
                  "extn": "5384"
              },
              {
                  "name": "Donna Snider",
                  "position": "Customer Support",
                  "salary": "$112,000",
                  "start_date": "2011/01/25",
                  "office": "New York",
                  "extn": "4226"
              }
            ];

            //return dataSet;
            return data;
    }


})();