Public Class Converter
    '********************************************************************************************* _
    'THE FUNCTIONS IN THIS MODULE ARE WRITTEN TO BE "STAND ALONE" WITH AS LITTLE DEPENDANCE _
    'ON OTHER FUNCTIONS AS POSSIBLE.  THIS MAKES THEM EASIER TO COPY TO OTHER VB APPLICATIONS. _
    'WHERE A FUNCTION DOES CALL ANOTHER FUNCTION THIS IS STATED IN THE COMMENTS AT THE START OF _
    'THE FUNCTION. _
    '*********************************************************************************************

    Function Helmert_X(X, Y, Z, DX, Y_Rot, Z_Rot, s)
        'Computed Helmert transformed X coordinate.
        'Input: - _cartesian XYZ coords (X,Y,Z), X translation (DX) all in meters ; _
        'Y and Z rotations in seconds of arc (Y_Rot, Z_Rot) and scale in ppm (s).

        'Convert rotations to radians and ppm scale to a factor
        Dim Pi = 3.14159265358979
        Dim sfactor = s * 0.000001
        Dim RadY_Rot = (Y_Rot / 3600) * (Pi / 180)
        Dim RadZ_Rot = (Z_Rot / 3600) * (Pi / 180)

        'Compute transformed X coord
        Helmert_X = X + (X * sfactor) - (Y * RadZ_Rot) + (Z * RadY_Rot) + DX

    End Function

    Function Helmert_Y(X, Y, Z, DY, X_Rot, Z_Rot, s)
        'Computed Helmert transformed Y coordinate.
        'Input: - _ cartesian XYZ coords (X,Y,Z), Y translation (DY) all in meters ; _
        ' X and Z rotations in seconds of arc (X_Rot, Z_Rot) and scale in ppm (s).

        'Convert rotations to radians and ppm scale to a factor
        Dim Pi = 3.14159265358979
        Dim sfactor = s * 0.000001
        Dim RadX_Rot = (X_Rot / 3600) * (Pi / 180)
        Dim RadZ_Rot = (Z_Rot / 3600) * (Pi / 180)

        'Compute transformed Y coord
        Helmert_Y = (X * RadZ_Rot) + Y + (Y * sfactor) - (Z * RadX_Rot) + DY

    End Function

    Function Helmert_Z(X, Y, Z, DZ, X_Rot, Y_Rot, s)
        'Computed Helmert transformed Z coordinate.
        'Input: - _cartesian XYZ coords (X,Y,Z), Z translation (DZ) all in meters ; _
        'X and Y rotations in seconds of arc (X_Rot, Y_Rot) and scale in ppm (s).

        'Convert rotations to radians and ppm scale to a factor
        Dim Pi = 3.14159265358979
        Dim sfactor = s * 0.000001
        Dim RadX_Rot = (X_Rot / 3600) * (Pi / 180)
        Dim RadY_Rot = (Y_Rot / 3600) * (Pi / 180)

        'Compute transformed Z coord
        Helmert_Z = (-1 * X * RadY_Rot) + (Y * RadX_Rot) + Z + (Z * sfactor) + DZ

    End Function

    Function XYZ_to_Lat(X, Y, Z, a, b)
        'Convert XYZ to Latitude (PHI) in Dec Degrees.
        'Input: - _XYZ cartesian coords (X,Y,Z) and ellipsoid axis dimensions (a & b), all in meters.

        'THIS FUNCTION REQUIRES THE "Iterate_XYZ_to_Lat" FUNCTION
        'THIS FUNCTION IS CALLED BY THE "XYZ_to_H" FUNCTION

        Dim RootXYSqr = Math.Sqrt((X ^ 2) + (Y ^ 2))
        Dim e2 = ((a ^ 2) - (b ^ 2)) / (a ^ 2)
        Dim PHI1 = Math.Atan(Z / (RootXYSqr * (1 - e2))) 'PHI1=Atn(Z / (RootXYSqr * (1 - e2)))

        Dim PHI = Iterate_XYZ_to_Lat(a, e2, PHI1, Z, RootXYSqr)

        Dim Pi = 3.14159265358979

        XYZ_to_Lat = PHI * (180 / Pi)

    End Function

    Function Iterate_XYZ_to_Lat(a, e2, PHI1, Z, RootXYSqr)
        'Iteratively computes Latitude (PHI).
        'Input: - _ellipsoid semi major axis (a) in meters; _
        'eta squared (e2); _
        'estimated value for latitude (PHI1) in radians; _
        'cartesian Z coordinate (Z) in meters; _
        'RootXYSqr computed from X & Y in meters.

        'THIS FUNCTION IS CALLED BY THE "XYZ_to_PHI" FUNCTION
        'THIS FUNCTION IS ALSO USED ON IT'S OWN IN THE _
        '"Projection and Transformation Calculations.xls" SPREADSHEET


        Dim V = a / (Math.Sqrt(1 - (e2 * ((Math.Sin(PHI1)) ^ 2))))
        Dim PHI2 = Math.Atan((Z + (e2 * V * (Math.Sin(PHI1)))) / RootXYSqr)

        Do While Math.Abs(PHI1 - PHI2) > 0.000000001
            PHI1 = PHI2
            V = a / (Math.Sqrt(1 - (e2 * ((Math.Sin(PHI1)) ^ 2))))
            PHI2 = Math.Atan((Z + (e2 * V * (Math.Sin(PHI1)))) / RootXYSqr)
        Loop

        Iterate_XYZ_to_Lat = PHI2

    End Function

    Function XYZ_to_Long(X, Y)
        'Convert XYZ to Longitude (LAM) in Dec Degrees.
        'Input: - _ X and Y cartesian coords in meters.

        Dim Pi = 3.14159265358979

        'tailor the output to fit the equatorial quadrant as determined by the signs of X and Y
        If X >= 0 Then 'longitude is in the W90 thru 0 to E90 hemisphere
            XYZ_to_Long = (Math.Atan(Y / X)) * (180 / Pi)
        End If

        If X < 0 And Y >= 0 Then 'longitude is in the E90 to E180 quadrant
            XYZ_to_Long = ((Math.Atan(Y / X)) * (180 / Pi)) + 180
        End If

        If X < 0 And Y < 0 Then 'longitude is in the E180 to W90 quadrant
            XYZ_to_Long = ((Math.Atan(Y / X)) * (180 / Pi)) - 180
        End If


    End Function

    Function XYZ_to_H(X, Y, Z, a, b)
        'Convert XYZ to Ellipsoidal Height.
        'Input: - _XYZ cartesian coords (X,Y,Z) and ellipsoid axis dimensions (a & b), all in meters.

        'REQUIRES THE "XYZ_to_Lat" FUNCTION

        'Compute PHI (Dec Degrees) first
        Dim PHI = XYZ_to_Lat(X, Y, Z, a, b)

        'Convert PHI radians
        Dim Pi = 3.14159265358979
        Dim RadPHI = PHI * (Pi / 180)

        'Compute H
        Dim RootXYSqr = Math.Sqrt((X ^ 2) + (Y ^ 2))
        Dim e2 = ((a ^ 2) - (b ^ 2)) / (a ^ 2)
        Dim V = a / (Math.Sqrt(1 - (e2 * ((Math.Sin(RadPHI)) ^ 2))))
        Dim H = (RootXYSqr / Math.Cos(RadPHI)) - V

        XYZ_to_H = H

    End Function

    Function Lat_Long_H_to_X(PHI, LAM, H, a, b)
        'Convert geodetic coords lat (PHI), long (LAM) and height (H) to cartesian X coordinate.
        'Input: - _Latitude (PHI)& Longitude (LAM) both in decimal degrees; _
        'Ellipsoidal height (H) and ellipsoid axis dimensions (a & b) all in meters.

        'Convert angle measures to radians
        Dim Pi = 3.14159265358979
        Dim RadPHI = PHI * (Pi / 180)
        Dim RadLAM = LAM * (Pi / 180)

        'Compute eccentricity squared and nu
        Dim e2 = ((a ^ 2) - (b ^ 2)) / (a ^ 2)
        Dim V = a / (Math.Sqrt(1 - (e2 * ((Math.Sin(RadPHI)) ^ 2))))

        'Compute X
        Lat_Long_H_to_X = (V + H) * (Math.Cos(RadPHI)) * (Math.Cos(RadLAM))

    End Function

    Function Lat_Long_H_to_Y(PHI, LAM, H, a, b)
        'Convert geodetic coords lat (PHI), long (LAM) and height (H) to cartesian Y coordinate.
        'Input: - _Latitude (PHI)& Longitude (LAM) both in decimal degrees; _
        'Ellipsoidal height (H) and ellipsoid axis dimensions (a & b) all in meters.

        'Convert angle measures to radians
        Dim Pi = 3.14159265358979
        Dim RadPHI = PHI * (Pi / 180)
        Dim RadLAM = LAM * (Pi / 180)

        'Compute eccentricity squared and nu
        Dim e2 = ((a ^ 2) - (b ^ 2)) / (a ^ 2)
        Dim V = a / (Math.Sqrt(1 - (e2 * ((Math.Sin(RadPHI)) ^ 2))))

        'Compute Y
        Lat_Long_H_to_Y = (V + H) * (Math.Cos(RadPHI)) * (Math.Sin(RadLAM))

    End Function

    Function Lat_H_to_Z(PHI, H, a, b)
        'Convert geodetic coord components latitude (PHI) and height (H) to cartesian Z coordinate.
        'Input: - _Latitude (PHI) decimal degrees; _
        'Ellipsoidal height (H) and ellipsoid axis dimensions (a & b) all in meters.

        'Convert angle measures to radians
        Dim Pi = 3.14159265358979
        Dim RadPHI = PHI * (Pi / 180)

        'Compute eccentricity squared and nu
        Dim e2 = ((a ^ 2) - (b ^ 2)) / (a ^ 2)
        Dim V = a / (Math.Sqrt(1 - (e2 * ((Math.Sin(RadPHI)) ^ 2))))

        'Compute X
        Lat_H_to_Z = ((V * (1 - e2)) + H) * (Math.Sin(RadPHI))

    End Function

    Function Lat_Long_to_East(PHI, LAM, a, b, e0, f0, PHI0, LAM0)
        'Project Latitude and longitude to Transverse Mercator eastings.
        'Input: - _
        'Latitude (PHI) and Longitude (LAM) in decimal degrees; _
        'ellipsoid axis dimensions (a & b) in meters; _
        'eastings of false origin (e0) in meters; _
        'central meridian scale factor (f0); _
        'latitude (PHI0) and longitude (LAM0) of false origin in decimal degrees.

        'Convert angle measures to radians
        Dim Pi = 3.14159265358979
        Dim RadPHI = PHI * (Pi / 180)
        Dim RadLAM = LAM * (Pi / 180)
        Dim RadPHI0 = PHI0 * (Pi / 180)
        Dim RadLAM0 = LAM0 * (Pi / 180)

        Dim af0 = a * f0
        Dim bf0 = b * f0
        Dim e2 = ((af0 ^ 2) - (bf0 ^ 2)) / (af0 ^ 2)
        Dim n = (af0 - bf0) / (af0 + bf0)
        Dim nu = af0 / (Math.Sqrt(1 - (e2 * ((Math.Sin(RadPHI)) ^ 2))))
        Dim rho = (nu * (1 - e2)) / (1 - (e2 * (Math.Sin(RadPHI)) ^ 2))
        Dim eta2 = (nu / rho) - 1
        Dim p = RadLAM - RadLAM0

        Dim IV = nu * (Math.Cos(RadPHI))
        Dim V = (nu / 6) * ((Math.Cos(RadPHI)) ^ 3) * ((nu / rho) - ((Math.Tan(RadPHI) ^ 2)))
        Dim VI = (nu / 120) * ((Math.Cos(RadPHI)) ^ 5) * (5 - (18 * ((Math.Tan(RadPHI)) ^ 2)) + ((Math.Tan(RadPHI)) ^ 4) + (14 * eta2) - (58 * ((Math.Tan(RadPHI)) ^ 2) * eta2))

        Lat_Long_to_East = e0 + (p * IV) + ((p ^ 3) * V) + ((p ^ 5) * VI)

    End Function

    Function Lat_Long_to_North(PHI, LAM, a, b, e0, n0, f0, PHI0, LAM0)
        'Project Latitude and longitude to Transverse Mercator northings
        'Input: - _
        'Latitude (PHI) and Longitude (LAM) in decimal degrees; _
        'ellipsoid axis dimensions (a & b) in meters; _
        'eastings (e0) and northings (n0) of false origin in meters; _
        'central meridian scale factor (f0); _
        'latitude (PHI0) and longitude (LAM0) of false origin in decimal degrees.

        'REQUIRES THE "Marc" FUNCTION

        'Convert angle measures to radians
        Dim Pi = 3.14159265358979
        Dim RadPHI = PHI * (Pi / 180)
        Dim RadLAM = LAM * (Pi / 180)
        Dim RadPHI0 = PHI0 * (Pi / 180)
        Dim RadLAM0 = LAM0 * (Pi / 180)

        Dim af0 = a * f0
        Dim bf0 = b * f0
        Dim e2 = ((af0 ^ 2) - (bf0 ^ 2)) / (af0 ^ 2)
        Dim n = (af0 - bf0) / (af0 + bf0)
        Dim nu = af0 / (Math.Sqrt(1 - (e2 * ((Math.Sin(RadPHI)) ^ 2))))
        Dim rho = (nu * (1 - e2)) / (1 - (e2 * (Math.Sin(RadPHI)) ^ 2))
        Dim eta2 = (nu / rho) - 1
        Dim p = RadLAM - RadLAM0
        Dim m = Marc(bf0, n, RadPHI0, RadPHI)

        Dim i = m + n0
        Dim II = (nu / 2) * (Math.Sin(RadPHI)) * (Math.Cos(RadPHI))
        Dim III = ((nu / 24) * (Math.Sin(RadPHI)) * ((Math.Cos(RadPHI)) ^ 3)) * (5 - ((Math.Tan(RadPHI)) ^ 2) + (9 * eta2))
        Dim IIIA = ((nu / 720) * (Math.Sin(RadPHI)) * ((Math.Cos(RadPHI)) ^ 5)) * (61 - (58 * ((Math.Tan(RadPHI)) ^ 2)) + ((Math.Tan(RadPHI)) ^ 4))

        Lat_Long_to_North = i + ((p ^ 2) * II) + ((p ^ 4) * III) + ((p ^ 6) * IIIA)

    End Function

    Function E_N_to_Lat(East, North, a, b, e0, n0, f0, PHI0, LAM0)
        'Un-project Transverse Mercator eastings and northings back to latitude.
        'Input: - _
        'eastings (East) and northings (North) in meters; _
        'ellipsoid axis dimensions (a & b) in meters; _
        'eastings (e0) and northings (n0) of false origin in meters; _
        'central meridian scale factor (f0) and _
        'latitude (PHI0) and longitude (LAM0) of false origin in decimal degrees.

        'REQUIRES THE "Marc" AND "InitialLat" FUNCTIONS

        'Convert angle measures to radians
        Dim Pi = 3.14159265358979
        Dim RadPHI0 = PHI0 * (Pi / 180)
        Dim RadLAM0 = LAM0 * (Pi / 180)

        'Compute af0, bf0, e squared (e2), n and Et
        Dim af0 = a * f0
        Dim bf0 = b * f0
        Dim e2 = ((af0 ^ 2) - (bf0 ^ 2)) / (af0 ^ 2)
        Dim n = (af0 - bf0) / (af0 + bf0)
        Dim Et = East - e0

        'Compute initial value for latitude (PHI) in radians
        Dim PHId = InitialLat(North, n0, af0, RadPHI0, n, bf0)

        'Compute nu, rho and eta2 using value for PHId
        Dim nu = af0 / (Math.Sqrt(1 - (e2 * ((Math.Sin(PHId)) ^ 2))))
        Dim rho = (nu * (1 - e2)) / (1 - (e2 * (Math.Sin(PHId)) ^ 2))
        Dim eta2 = (nu / rho) - 1

        'Compute Latitude
        Dim VII = (Math.Tan(PHId)) / (2 * rho * nu)
        Dim VIII = ((Math.Tan(PHId)) / (24 * rho * (nu ^ 3))) * (5 + (3 * ((Math.Tan(PHId)) ^ 2)) + eta2 - (9 * eta2 * ((Math.Tan(PHId)) ^ 2)))
        Dim IX = ((Math.Tan(PHId)) / (720 * rho * (nu ^ 5))) * (61 + (90 * ((Math.Tan(PHId)) ^ 2)) + (45 * ((Math.Tan(PHId)) ^ 4)))

        E_N_to_Lat = (180 / Pi) * (PHId - ((Et ^ 2) * VII) + ((Et ^ 4) * VIII) - ((Et ^ 6) * IX))

    End Function

    Function E_N_to_Long(East, North, a, b, e0, n0, f0, PHI0, LAM0)
        'Un-project Transverse Mercator eastings and northings back to longitude.
        'Input: - _
        'eastings (East) and northings (North) in meters; _
        'ellipsoid axis dimensions (a & b) in meters; _
        'eastings (e0) and northings (n0) of false origin in meters; _
        'central meridian scale factor (f0) and _
        'latitude (PHI0) and longitude (LAM0) of false origin in decimal degrees.

        'REQUIRES THE "Marc" AND "InitialLat" FUNCTIONS

        'Convert angle measures to radians
        Dim Pi = 3.14159265358979
        Dim RadPHI0 = PHI0 * (Pi / 180)
        Dim RadLAM0 = LAM0 * (Pi / 180)

        'Compute af0, bf0, e squared (e2), n and Et
        Dim af0 = a * f0
        Dim bf0 = b * f0
        Dim e2 = ((af0 ^ 2) - (bf0 ^ 2)) / (af0 ^ 2)
        Dim n = (af0 - bf0) / (af0 + bf0)
        Dim Et = East - e0

        'Compute initial value for latitude (PHI) in radians
        Dim PHId = InitialLat(North, n0, af0, RadPHI0, n, bf0)

        'Compute nu, rho and eta2 using value for PHId
        Dim nu = af0 / (Math.Sqrt(1 - (e2 * ((Math.Sin(PHId)) ^ 2))))
        Dim rho = (nu * (1 - e2)) / (1 - (e2 * (Math.Sin(PHId)) ^ 2))
        Dim eta2 = (nu / rho) - 1

        'Compute Longitude
        Dim X = ((Math.Cos(PHId)) ^ -1) / nu
        Dim XI = (((Math.Cos(PHId)) ^ -1) / (6 * (nu ^ 3))) * ((nu / rho) + (2 * ((Math.Tan(PHId)) ^ 2)))
        Dim XII = (((Math.Cos(PHId)) ^ -1) / (120 * (nu ^ 5))) * (5 + (28 * ((Math.Tan(PHId)) ^ 2)) + (24 * ((Math.Tan(PHId)) ^ 4)))
        Dim XIIA = (((Math.Cos(PHId)) ^ -1) / (5040 * (nu ^ 7))) * (61 + (662 * ((Math.Tan(PHId)) ^ 2)) + (1320 * ((Math.Tan(PHId)) ^ 4)) + (720 * ((Math.Tan(PHId)) ^ 6)))

        E_N_to_Long = (180 / Pi) * (RadLAM0 + (Et * X) - ((Et ^ 3) * XI) + ((Et ^ 5) * XII) - ((Et ^ 7) * XIIA))

    End Function

    Function InitialLat(North, n0, afo, PHI0, n, bfo)
        'Compute initial value for Latitude (PHI) IN RADIANS.
        'Input: - _
        'northing of point (North) and northing of false origin (n0) in meters; _
        'semi major axis multiplied by central meridian scale factor (af0) in meters; _
        'latitude of false origin (PHI0) IN RADIANS; _
        'n (computed from a, b and f0) and _
        'ellipsoid semi major axis multiplied by central meridian scale factor (bf0) in meters.

        'REQUIRES THE "Marc" FUNCTION
        'THIS FUNCTION IS CALLED BY THE "E_N_to_Lat", "E_N_to_Long" and "E_N_to_C" FUNCTIONS
        'THIS FUNCTION IS ALSO USED ON IT'S OWN IN THE  "Projection and Transformation Calculations.xls" SPREADSHEET

        'First PHI value (PHI1)
        Dim PHI1 = ((North - n0) / afo) + PHI0

        'Calculate M
        Dim m = Marc(bfo, n, PHI0, PHI1)

        'Calculate new PHI value (PHI2)
        Dim PHI2 = ((North - n0 - m) / afo) + PHI1

        'Iterate to get final value for InitialLat
        Do While Math.Abs(North - n0 - m) > 0.00001
            PHI2 = ((North - n0 - m) / afo) + PHI1
            m = Marc(bfo, n, PHI0, PHI2)
            PHI1 = PHI2
        Loop

        InitialLat = PHI2

    End Function

    Function Marc(bf0, n, PHI0, PHI)
        'Compute meridional arc.
        'Input: - _
        'ellipsoid semi major axis multiplied by central meridian scale factor (bf0) in meters; _
        'n (computed from a, b and f0); _
        'lat of false origin (PHI0) and initial or final latitude of point (PHI) IN RADIANS.

        'THIS FUNCTION IS CALLED BY THE - _"Lat_Long_to_North" and "InitialLat" FUNCTIONS
        'THIS FUNCTION IS ALSO USED ON IT'S OWN IN THE "Projection and Transformation Calculations.xls" SPREADSHEET

        Marc = bf0 * (((1 + n + ((5 / 4) * (n ^ 2)) + ((5 / 4) * (n ^ 3))) * (PHI - PHI0)) _
        - (((3 * n) + (3 * (n ^ 2)) + ((21 / 8) * (n ^ 3))) * (Math.Sin(PHI - PHI0)) * (Math.Cos(PHI + PHI0))) _
        + ((((15 / 8) * (n ^ 2)) + ((15 / 8) * (n ^ 3))) * (Math.Sin(2 * (PHI - PHI0))) * (Math.Cos(2 * (PHI + PHI0)))) _
        - (((35 / 24) * (n ^ 3)) * (Math.Sin(3 * (PHI - PHI0))) * (Math.Cos(3 * (PHI + PHI0)))))

    End Function

    Function Lat_Long_to_C(PHI, LAM, LAM0, a, b, f0)
        'Compute convergence (in decimal degrees) from latitude and longitude
        'Input: - _
        'latitude (PHI), longitude (LAM) and longitude (LAM0) of false origin in decimal degrees; _
        'ellipsoid axis dimensions (a & b) in meters; _
        'central meridian scale factor (f0).

        'Convert angle measures to radians
        Dim Pi = 3.14159265358979
        Dim RadPHI = PHI * (Pi / 180)
        Dim RadLAM = LAM * (Pi / 180)
        Dim RadLAM0 = LAM0 * (Pi / 180)

        'Compute af0, bf0 and e squared (e2)
        Dim af0 = a * f0
        Dim bf0 = b * f0
        Dim e2 = ((af0 ^ 2) - (bf0 ^ 2)) / (af0 ^ 2)

        'Compute nu, rho, eta2 and p
        Dim nu = af0 / (Math.Sqrt(1 - (e2 * ((Math.Sin(RadPHI)) ^ 2))))
        Dim rho = (nu * (1 - e2)) / (1 - (e2 * (Math.Sin(RadPHI)) ^ 2))
        Dim eta2 = (nu / rho) - 1
        Dim p = RadLAM - RadLAM0

        'Compute Convergence
        Dim XIII = Math.Sin(RadPHI)
        Dim XIV = ((Math.Sin(RadPHI) * ((Math.Cos(RadPHI)) ^ 2)) / 3) * (1 + (3 * eta2) + (2 * (eta2 ^ 2)))
        Dim XV = ((Math.Sin(RadPHI) * ((Math.Cos(RadPHI)) ^ 4)) / 15) * (2 - ((Math.Tan(RadPHI)) ^ 2))

        Lat_Long_to_C = (180 / Pi) * ((p * XIII) + ((p ^ 3) * XIV) + ((p ^ 5) * XV))

    End Function

    Function E_N_to_C(East, North, a, b, e0, n0, f0, PHI0)
        'Compute convergence (in decimal degrees) from easting and northing
        'Input: - _
        'Eastings (East) and Northings (North) in meters; _
        'ellipsoid axis dimensions (a & b) in meters; _
        'easting (e0) and northing (n0) of true origin in meters; _
        'central meridian scale factor (f0); _
        'latitude of central meridian (PHI0) in decimal degrees.

        'REQUIRES THE "Marc" AND "InitialLat" FUNCTIONS

        'Convert angle measures to radians
        Dim Pi = 3.14159265358979
        Dim RadPHI0 = PHI0 * (Pi / 180)

        'Compute af0, bf0, e squared (e2), n and Et
        Dim af0 = a * f0
        Dim bf0 = b * f0
        Dim e2 = ((af0 ^ 2) - (bf0 ^ 2)) / (af0 ^ 2)
        Dim n = (af0 - bf0) / (af0 + bf0)
        Dim Et = East - e0

        'Compute initial value for latitude (PHI) in radians
        Dim PHId = InitialLat(North, n0, af0, RadPHI0, n, bf0)

        'Compute nu, rho and eta2 using value for PHId
        Dim nu = af0 / (Math.Sqrt(1 - (e2 * ((Math.Sin(PHId)) ^ 2))))
        Dim rho = (nu * (1 - e2)) / (1 - (e2 * (Math.Sin(PHId)) ^ 2))
        Dim eta2 = (nu / rho) - 1

        'Compute Convergence
        Dim XVI = (Math.Tan(PHId)) / nu
        Dim XVII = ((Math.Tan(PHId)) / (3 * (nu ^ 3))) * (1 + ((Math.Tan(PHId)) ^ 2) - eta2 - (2 * (eta2 ^ 2)))
        Dim XVIII = ((Math.Tan(PHId)) / (15 * (nu ^ 5))) * (2 + (5 * ((Math.Tan(PHId)) ^ 2)) + (3 * ((Math.Tan(PHId)) ^ 4)))

        E_N_to_C = (180 / Pi) * ((Et * XVI) - ((Et ^ 3) * XVII) + ((Et ^ 5) * XVIII))

    End Function

    Function Lat_Long_to_LSF(PHI, LAM, LAM0, a, b, f0)
        'Compute local scale factor from latitude and longitude
        'Input: - _
        'latitude (PHI), longitude (LAM) and longitude (LAM0) of false origin in decimal degrees; _
        'ellipsoid axis dimensions (a & b) in meters; _
        'central meridian scale factor (f0).

        'Convert angle measures to radians
        Dim Pi = 3.14159265358979
        Dim RadPHI = PHI * (Pi / 180)
        Dim RadLAM = LAM * (Pi / 180)
        Dim RadLAM0 = LAM0 * (Pi / 180)

        'Compute af0, bf0 and e squared (e2)
        Dim af0 = a * f0
        Dim bf0 = b * f0
        Dim e2 = ((af0 ^ 2) - (bf0 ^ 2)) / (af0 ^ 2)

        'Compute nu, rho, eta2 and p
        Dim nu = af0 / (Math.Sqrt(1 - (e2 * ((Math.Sin(RadPHI)) ^ 2))))
        Dim rho = (nu * (1 - e2)) / (1 - (e2 * (Math.Sin(RadPHI)) ^ 2))
        Dim eta2 = (nu / rho) - 1
        Dim p = RadLAM - RadLAM0

        'Compute local scale factor
        Dim XIX = ((Math.Cos(RadPHI) ^ 2) / 2) * (1 + eta2)
        Dim XX = ((Math.Cos(RadPHI) ^ 4) / 24) * (5 - (4 * ((Math.Tan(RadPHI)) ^ 2)) + (14 * eta2) - (28 * ((Math.Tan(RadPHI * eta2)) ^ 2)))

        Lat_Long_to_LSF = f0 * (1 + ((p ^ 2) * XIX) + ((p ^ 4) * XX))

    End Function

    Function E_N_to_LSF(East, North, a, b, e0, n0, f0, PHI0)
        'Compute local scale factor from from easting and northing
        'Input: - _
        'Eastings (East) and Northings (North) in meters; _
        'ellipsoid axis dimensions (a & b) in meters; _
        'easting (e0) and northing (n0) of true origin in meters; _
        'central meridian scale factor (f0); _
        'latitude of central meridian (PHI0) in decimal degrees.

        'REQUIRES THE "Marc" AND "InitialLat" FUNCTIONS

        'Convert angle measures to radians
        Dim Pi = 3.14159265358979
        Dim RadPHI0 = PHI0 * (Pi / 180)

        'Compute af0, bf0, e squared (e2), n and Et
        Dim af0 = a * f0
        Dim bf0 = b * f0
        Dim e2 = ((af0 ^ 2) - (bf0 ^ 2)) / (af0 ^ 2)
        Dim n = (af0 - bf0) / (af0 + bf0)
        Dim Et = East - e0

        'Compute initial value for latitude (PHI) in radians
        Dim PHId = InitialLat(North, n0, af0, RadPHI0, n, bf0)

        'Compute nu, rho and eta2 using value for PHId
        Dim nu = af0 / (Math.Sqrt(1 - (e2 * ((Math.Sin(PHId)) ^ 2))))
        Dim rho = (nu * (1 - e2)) / (1 - (e2 * (Math.Sin(PHId)) ^ 2))
        Dim eta2 = (nu / rho) - 1

        'Compute local scale factor
        Dim XXI = 1 / (2 * rho * nu)
        Dim XXII = (1 + (4 * eta2)) / (24 * (rho ^ 2) * (nu ^ 2))

        E_N_to_LSF = f0 * (1 + ((Et ^ 2) * XXI) + ((Et ^ 4) * XXII))

    End Function

    Function E_N_to_t_minus_T(AtEast, AtNorth, ToEast, ToNorth, a, b, e0, n0, f0, PHI0)
        'Compute (t-T) correction in decimal degrees at point (AtEast, AtNorth) to point (ToEast,ToNorth)
        'Input: - _
        'Eastings (AtEast) and Northings (AtNorth) in meters, of point where (t-T) is being computed; _
        'Eastings (ToEast) and Northings (ToNorth) in meters, of point at other end of line to which (t-T) is being computed; _
        'ellipsoid axis dimensions (a & b) and easting & northing (e0 & n0) of true origin in meters; _
        'central meridian scale factor (f0); _
        'latitude of central meridian (PHI0) in decimal degrees.

        'REQUIRES THE "Marc" AND "InitialLat" FUNCTIONS

        'Convert angle measures to radians
        Dim Pi = 3.14159265358979
        Dim RadPHI0 = PHI0 * (Pi / 180)

        'Compute af0, bf0, e squared (e2), n and Nm (Northing of mid point)
        Dim af0 = a * f0
        Dim bf0 = b * f0
        Dim e2 = ((af0 ^ 2) - (bf0 ^ 2)) / (af0 ^ 2)
        Dim n = (af0 - bf0) / (af0 + bf0)
        Dim Nm = (AtNorth + ToNorth) / 2

        'Compute initial value for latitude (PHI) in radians
        Dim PHId = InitialLat(Nm, n0, af0, RadPHI0, n, bf0)

        'Compute nu, rho and eta2 using value for PHId
        Dim nu = af0 / (Math.Sqrt(1 - (e2 * ((Math.Sin(PHId)) ^ 2))))
        Dim rho = (nu * (1 - e2)) / (1 - (e2 * (Math.Sin(PHId)) ^ 2))

        'Compute (t-T)
        Dim XXIII = 1 / (6 * nu * rho)

        E_N_to_t_minus_T = (180 / Pi) * ((2 * (AtEast - e0)) + (ToEast - e0)) * (AtNorth - ToNorth) * XXIII

    End Function

    Function TrueAzimuth(AtEast, AtNorth, ToEast, ToNorth, a, b, e0, n0, f0, PHI0)
        'Compute true azimuth in decimal degrees at point (AtEast, AtNorth) to point (ToEast,ToNorth)
        'Input: - _
        'Eastings (AtEast) and Northings (AtNorth) in meters, of point where true azimuth is being computed; _
        'Eastings (ToEast) and Northings (ToNorth) in meters, of point at other end of line to which true azimuth is being computed; _
        'ellipsoid axis dimensions (a & b) and easting & northing (e0 & n0) of true origin in meters; _
        'central meridian scale factor (f0); _
        'latitude of central meridian (PHI0) in decimal degrees.

        'REQUIRES THE "Marc", "InitialLat", "E_N_to_t_minus_T" and "E_N_to_C" FUNCTIONS

        'Compute eastings and northings differences
        Dim Diffe = ToEast - AtEast
        Dim Diffn = ToNorth - AtNorth

        Dim GridBearing
        'Compute grid bearing
        If Diffe = 0 Then
            If Diffn < 0 Then
                GridBearing = 180
            Else
                GridBearing = 0
            End If
            GoTo EndOfComputeBearing
        End If

        Dim Ratio = Diffn / Diffe
        Dim Pi = 3.14159265358979
        Dim GridAngle = (180 / Pi) * Math.Atan(Ratio)

        If Diffe > 0 Then
            GridBearing = 90 - GridAngle
        End If

        If Diffe < 0 Then
            GridBearing = 270 - GridAngle
        End If
EndOfComputeBearing:

        'Compute convergence
        Dim Convergence = E_N_to_C(AtEast, AtNorth, a, b, e0, n0, f0, PHI0)

        'Compute (t-T) correction
        Dim t_minus_T = E_N_to_t_minus_T(AtEast, AtNorth, ToEast, ToNorth, a, b, e0, n0, f0, PHI0)

        'Compute initial azimuth
        Dim InitAzimuth = GridBearing + Convergence - t_minus_T

        'Set TrueAzimuth >=0 and <=360
        If InitAzimuth < 0 Then
            TrueAzimuth = InitAzimuth + 360
        ElseIf InitAzimuth > 360 Then
            TrueAzimuth = InitAzimuth - 360
        Else
            TrueAzimuth = InitAzimuth
        End If

    End Function


    '*************************************************************
    Private Const PI = 3.14159265358979
    Private Const EPSILON As Double = 0.000000000001

    Public Function distVincenty(ByVal lat1 As Double, ByVal lon1 As Double, _
        ByVal lat2 As Double, ByVal lon2 As Double) As Double
        'INPUTS: Latitude and Longitude of initial and 
        '           destination points in decimal format.
        'OUTPUT: Distance between the two points in Meters.
        '
        '======================================
        ' Calculate geodesic distance (in m) between two points specified by
        ' latitude/longitude (in numeric [decimal] degrees)
        ' using Vincenty inverse formula for ellipsoids
        '======================================
        ' Code has been ported by lost_species from www.aliencoffee.co.uk to VBA
        ' from javascript published at:
        ' http://www.movable-type.co.uk/scripts/latlong-vincenty.html
        ' * from: Vincenty inverse formula - T Vincenty, "Direct and Inverse Solutions
        ' *       of Geodesics on the Ellipsoid with application
        ' *       of nested equations", Survey Review, vol XXII no 176, 1975
        ' *       http://www.ngs.noaa.gov/PUBS_LIB/inverse.pdf
        'Additional Reference: http://en.wikipedia.org/wiki/Vincenty%27s_formulae
        '======================================
        ' Copyright lost_species 2008 LGPL 
        ' http://www.fsf.org/licensing/licenses/lgpl.html
        '======================================
        ' Code modifications to prevent "Formula Too Complex" errors
        ' in Excel (2010) VBA implementation
        ' provided by Jerry Latham, Microsoft MVP Excel Group, 2005-2011
        ' July 23 2011
        '======================================

        Dim low_a As Double
        Dim low_b As Double
        Dim f As Double
        Dim L As Double
        Dim U1 As Double
        Dim U2 As Double
        Dim sinU1 As Double
        Dim sinU2 As Double
        Dim cosU1 As Double
        Dim cosU2 As Double
        Dim lambda As Double
        Dim lambdaP As Double
        Dim iterLimit As Integer
        Dim sinLambda As Double
        Dim cosLambda As Double
        Dim sinSigma As Double
        Dim cosSigma As Double
        Dim sigma As Double
        Dim sinAlpha As Double
        Dim cosSqAlpha As Double
        Dim cos2SigmaM As Double
        Dim C As Double
        Dim uSq As Double
        Dim upper_A As Double
        Dim upper_B As Double
        Dim deltaSigma As Double
        Dim s As Double ' final result, will be returned rounded to 3 decimals (mm).
        'added by JLatham to break up "Too Complex" formulas
        'into pieces to properly calculate those formulas as noted below
        'and to prevent overflow errors when using
        'Excel 2010 x64 on Windows 7 x64 systems
        Dim P1 As Double ' used to calculate a portion of a complex formula
        Dim P2 As Double ' used to calculate a portion of a complex formula
        Dim P3 As Double ' used to calculate a portion of a complex formula

        'See http://en.wikipedia.org/wiki/World_Geodetic_System
        'for information on various Ellipsoid parameters for other standards.
        'low_a and low_b in meters
        ' === GRS-80 ===
        ' low_a = 6378137
        ' low_b = 6356752.314245
        ' f = 1 / 298.257223563
        '
        ' === Airy 1830 ===  Reported best accuracy for England and Northern Europe.
        ' low_a = 6377563.396
        ' low_b = 6356256.910
        ' f = 1 / 299.3249646
        '
        ' === International 1924 ===
        ' low_a = 6378388
        ' low_b = 6356911.946
        ' f = 1 / 297
        '
        ' === Clarke Model 1880 ===
        ' low_a = 6378249.145
        ' low_b = 6356514.86955
        ' f = 1 / 293.465
        '
        ' === GRS-67 ===
        ' low_a = 6378160
        ' low_b = 6356774.719
        ' f = 1 / 298.247167

        '=== WGS-84 Ellipsoid Parameters ===
        low_a = 6378137       ' +/- 2m
        low_b = 6356752.3142
        f = 1 / 298.257223563
        '====================================
        L = toRad(lon2 - lon1)
        U1 = Math.Atan((1 - f) * Math.Tan(toRad(lat1)))
        U2 = Math.Atan((1 - f) * Math.Tan(toRad(lat2)))
        sinU1 = Math.Sin(U1)
        cosU1 = Math.Cos(U1)
        sinU2 = Math.Sin(U2)
        cosU2 = Math.Cos(U2)

        lambda = L
        lambdaP = 2 * PI
        iterLimit = 100 ' can be set as low as 20 if desired.

        While (Math.Abs(lambda - lambdaP) > EPSILON) And (iterLimit > 0)
            iterLimit = iterLimit - 1

            sinLambda = Math.Sin(lambda)
            cosLambda = Math.Cos(lambda)
            sinSigma = Math.Sqrt(((cosU2 * sinLambda) ^ 2) + _
                ((cosU1 * sinU2 - sinU1 * cosU2 * cosLambda) ^ 2))
            If sinSigma = 0 Then
                distVincenty = 0  'co-incident points
                Exit Function
            End If
            cosSigma = sinU1 * sinU2 + cosU1 * cosU2 * cosLambda
            sigma = Atan2(cosSigma, sinSigma)
            sinAlpha = cosU1 * cosU2 * sinLambda / sinSigma
            cosSqAlpha = 1 - sinAlpha * sinAlpha

            If cosSqAlpha = 0 Then 'check for a divide by zero
                cos2SigmaM = 0 '2 points on the equator
            Else
                cos2SigmaM = cosSigma - 2 * sinU1 * sinU2 / cosSqAlpha
            End If

            C = f / 16 * cosSqAlpha * (4 + f * (4 - 3 * cosSqAlpha))
            lambdaP = lambda

            'the original calculation is "Too Complex" for Excel VBA to deal with
            'so it is broken into segments to calculate without that issue
            'the original implementation to calculate lambda
            'lambda = L + (1 - C) * f * sinAlpha * (sigma + C * sinSigma * (cos2SigmaM + C * cosSigma * (-1 + 2 * (cos2SigmaM ^ 2))))
            'calculate portions
            P1 = -1 + 2 * (cos2SigmaM ^ 2)
            P2 = (sigma + C * sinSigma * (cos2SigmaM + C * cosSigma * P1))
            'complete the calculation
            lambda = L + (1 - C) * f * sinAlpha * P2

        End While

        If iterLimit < 1 Then
            MsgBox("iteration limit has been reached, something didn't work.")
            Exit Function
        End If

        uSq = cosSqAlpha * (low_a ^ 2 - low_b ^ 2) / (low_b ^ 2)

        'the original calculation is "Too Complex" for Excel VBA to deal with
        'so it is broken into segments to calculate without that issue
        'the original implementation to calculate upper_A
        'upper_A = 1 + uSq / 16384 * (4096 + uSq * (-768 + uSq * (320 - 175 * uSq)))
        'calculate one piece of the equation
        P1 = (4096 + uSq * (-768 + uSq * (320 - 175 * uSq)))
        'complete the calculation
        upper_A = 1 + uSq / 16384 * P1

        'oddly enough, upper_B calculates without any issues - JLatham
        upper_B = uSq / 1024 * (256 + uSq * (-128 + uSq * (74 - 47 * uSq)))

        'the original calculation is "Too Complex" for Excel VBA to deal with
        'so it is broken into segments to calculate without that issue
        'the original implementation to calculate deltaSigma
        'deltaSigma = upper_B * sinSigma * (cos2SigmaM + upper_B / 4 * (cosSigma * (-1 + 2 * cos2SigmaM ^ 2) - upper_B / 6 * cos2SigmaM * (-3 + 4 * sinSigma ^ 2) * (-3 + 4 * cos2SigmaM ^ 2)))
        'calculate pieces of the deltaSigma formula
        'broken into 3 pieces to prevent overflow error that may occur in
        'Excel 2010 64-bit version.
        P1 = (-3 + 4 * sinSigma ^ 2) * (-3 + 4 * cos2SigmaM ^ 2)
        P2 = upper_B * sinSigma
        P3 = (cos2SigmaM + upper_B / 4 * (cosSigma * (-1 + 2 * cos2SigmaM ^ 2) - upper_B / 6 * cos2SigmaM * P1))
        'complete the deltaSigma calculation
        deltaSigma = P2 * P3

        'calculate the distance
        s = low_b * upper_A * (sigma - deltaSigma)
        'round distance to millimeters
        distVincenty = Math.Round(s, 3)

    End Function

    Function SignIt(Degree_Dec As String) As Double
        'Input:   a string representation of a lat or long in the
        '         format of 10° 27' 36" S/N  or 10~ 27' 36" E/W
        'OUTPUT:  signed decimal value ready to convert to radians
        '
        Dim decimalValue As Double
        Dim tempString As String
        tempString = UCase(Trim(Degree_Dec))
        decimalValue = Convert_Decimal(tempString)
        If Right(tempString, 1) = "S" Or Right(tempString, 1) = "W" Then
            decimalValue = decimalValue * -1
        End If
        SignIt = decimalValue
    End Function

    Function Convert_Degree(Decimal_Deg) As Object
        'source: http://support.microsoft.com/kb/213449
        '
        'converts a decimal degree representation to deg min sec
        'as 10.46 returns 10° 27' 36"
        '
        Dim degrees As Object
        Dim minutes As Object
        Dim seconds As Object
        ' With Application
        'Set degree to Integer of Argument Passed
        degrees = Int(Decimal_Deg)
        'Set minutes to 60 times the number to the right
        'of the decimal for the variable Decimal_Deg
        minutes = (Decimal_Deg - degrees) * 60
        'Set seconds to 60 times the number to the right of the
        'decimal for the variable Minute
        seconds = Format(((minutes - Int(minutes)) * 60), "0")
        'Returns the Result of degree conversion
        '(for example, 10.46 = 10° 27' 36")
        Convert_Degree = " " & degrees & "° " & Int(minutes) & "' " _
            & seconds + Chr(34)
        ' End With
    End Function

    Function Convert_Decimal(Degree_Deg As String) As Double
        'source: http://support.microsoft.com/kb/213449
        ' Declare the variables to be double precision floating-point.
        ' Converts text angular entry to decimal equivalent, as:
        ' 10° 27' 36" returns 10.46
        ' alternative to ° is permitted: Use ~ instead, as:
        ' 10~ 27' 36" also returns 10.46
        Dim degrees As Double
        Dim minutes As Double
        Dim seconds As Double
        '
        'modification by JLatham
        'allow the user to use the ~ symbol instead of ° to denote degrees
        'since ~ is available from the keyboard and ° has to be entered
        'through [Alt] [0] [1] [7] [6] on the number pad.
        Degree_Deg = Replace(Degree_Deg, "~", "°")

        ' Set degree to value before "°" of Argument Passed.
        degrees = Val(Left(Degree_Deg, InStr(1, Degree_Deg, "°") - 1))
        ' Set minutes to the value between the "°" and the "'"
        ' of the text string for the variable Degree_Deg divided by
        ' 60. The Val function converts the text string to a number.
        minutes = Val(Mid(Degree_Deg, InStr(1, Degree_Deg, "°") + 2, _
                  InStr(1, Degree_Deg, "'") - InStr(1, Degree_Deg, "°") - 2)) / 60
        ' Set seconds to the number to the right of "'" that is
        ' converted to a value and then divided by 3600.
        seconds = Val(Mid(Degree_Deg, InStr(1, Degree_Deg, "'") + _
                2, Len(Degree_Deg) - InStr(1, Degree_Deg, "'") - 2)) / 3600
        Convert_Decimal = degrees + minutes + seconds
    End Function

    Private Function toRad(ByVal degrees As Double) As Double
        toRad = degrees * (PI / 180)
    End Function

    Private Function Atan2(ByVal X As Double, ByVal Y As Double) As Double
        ' code nicked from:
        ' http://en.wikibooks.org/wiki/Programming:Visual_Basic_Classic
        '  /Simple_Arithmetic#Trigonometrical_Functions
        ' If you re-use this watch out: the x and y have been reversed from typical use.
        If Y > 0 Then
            If X >= Y Then
                Atan2 = Math.Atan(Y / X)
            ElseIf X <= -Y Then
                Atan2 = Math.Atan(Y / X) + PI
            Else
                Atan2 = PI / 2 - Math.Atan(X / Y)
            End If
        Else
            If X >= -Y Then
                Atan2 = Math.Atan(Y / X)
            ElseIf X <= Y Then
                Atan2 = Math.Atan(Y / X) - PI
            Else
                Atan2 = -Math.Atan(X / Y) - PI / 2
            End If
        End If
    End Function
    '======================================
End Class
