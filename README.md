# SmartPark

המערכת תנהל זרימת רכבים אל החניון וממנו
יהיו תהליכים כגון:
כניסת רכב לחניון
יציאת רכב מהחניון
חישוב תעריף
הזמנת מקום

יהיו כמה סוגי חניות, כל סוג כלי רכב יהיה סוג חניה.

תהיה חניה כללית אבסטרקטית ממנה ירשו:
רכב רגיל
רכב נכה
אופנוע

המתודה להיכנס לחניון תהיה על כל סוגי החניות
המתודה לצאת מהחניון תהיה עלכל סוגי החניות
המתודה של חישוב תעריף תכול על כל סוגי החניות

יהיו שתי סוגים של תשלום :
מזומן
אשראי



האופציה לשמירת מקום תחול רק על רכבים רגילים ורכבי נכים.


abstract class GeneralPark:
- entry
- exit
- void Enter()
- void Exit ()
-  override int Calculate()
- IPayment Pay()

class RegularCarPark : GeneralPark, IOrderable  
- orderSpot()
ואת כל האובררייד של האבא

class HandiCap : GeneralPark, IOrderable  
- orderSpot()
ואת כל האובררייד של האבא

class BikePark : GeneralPark
ואת כל האובררייד של האבא


ממשקים:
interface IOrderable
        - void orderSpot{}
        לרכבים עם יכולת לשמור מקום מראש

interface IPayment
        - void Pay(){}
        לשני סוגי התשלום 

interface IRecordable
        - void Record(){}
        לתעד חניה
        ולתיעוד שגיאה של הזמנים


class InvalidExitTime : Exception - לתפיסת בעיות בזמני החניה 
class InvalidExiting : Exception - אם מוציא רכב שכבר בחוץ  
EmptyParking : Exception - נסיון לגשת לחניה ריקה

class RecordPark : IRecordable - לתיעוד החניות
class RecordError : IRecordable - לתעד שגיאה של זמן


Main:

בדיקה איזה רכב נכנס
יצירת חניה לפי הסוג
הצעה לתפיסת מקום: התאמה לסוג!
הפעלת כניסה הפעלת יציאה -נסיון:
אם נכשל תיעוד והמשכת flow
הפעלת תשלום לפי סוג נבחר
תיעוד חניה 
