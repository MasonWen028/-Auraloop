﻿using NeteaseCloudMusicSDK.ApiClient;

namespace NexteaseCloudMusicSDK.WebApi.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly RequestContext _context;

        public AuthMiddleware(RequestDelegate next, RequestContext context)
        {
            _next = next;
            _context = context;
        }

        //Process the cookie
        public async Task Invoke(HttpContext context)
        {
            //GET the cookie string from front end or other place

            _context.Cookie = "MUSIC_R_T=1415771372239; MUSIC_A_T=1415771283000; NMTID=00O7qNg3YLIVHdQMkR0vRdbg9spStcAAAGUGnttWQ; _iuqxldmzr_=32; _ntes_nnid=c63b8ed37551a0d21cdd8d09431f74f3,1735715018356; _ntes_nuid=c63b8ed37551a0d21cdd8d09431f74f3; WEVNSM=1.0.0; WNMCID=pczbkm.1735715018881.01.0; sDeviceId=YD-LXGZGKBHf8FEQlFVEFaSdUgFmKdyvzed; P_INFO=18281597679|1735883543|1|music|00&99|null&null&null#AU&null#10#0|&0||18281597679; MUSIC_U=005F14D98085815617A46F437C40963858A89F21C6298AF32C5C2A19A880D6C6AF932D7E4D81158F2A9622830AE0EFAF0BB2C0D9265C0CD6EB6EA8474DC4C824C0E6EB5D338F4C5AB00478AA679972652185CAE8BEF0F75AB68A658854AEB8A1FAFCB1DDE95D9D19DC815524F401E3530B699E55538131CB4AEF07F5EA2F045BB0AA4DB7133558C97E5EE374FEDF8BBFCF1B84AE0A075C6CCB5D1BF3F89F713C14ED01CD2F95172AF95D40437B8DBB871B76C0A6973D307D503D16E7C8348D9A023F705599BD1817E766EE19E1F8B79085E3E1C82D4C8FE5FF8EA2E11497FCE57A79EBD058827A1118EB2A2F0F742070D6A69217CD3A4B7A9A56E9AF0CBEFA4E1E57DD45F5AA7D43E349FA333ACBC91B81FF224AC6D322F28BD1CDBAB65C3D17770E488BA70E970E35F82F066DFA79635490EA3F89AEC9502342644FD4AA317371E4F679270826D82F631CB71A25E1D57DA33EE897395C6F1724F13514D9928A3E; __csrf=79a62388899b286e3d57511174527b9b; __remember_me=true; ntes_kaola_ad=1; JSESSIONID-WYYY=ttmSxQZwkVcOK1K%2FSurEdO9hbC20epz%2Fyl4F8p7O8nKlipYa78TnvBNcPw2NT%2FIl8weksaZwztx3briJqTEqxfyuCpnBoCAkylN9Ir0BHJTJCgWuvvjy3%5CZVJPT%5C%2Fc8S7q3nCm5lhSCqoCK8Nb7NGahSWH486KmbwHa0vEu92B8JEvga%3A1736321955284";
            await _next(context);
        }
    }
}