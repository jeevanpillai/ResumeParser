from pyresparser import ResumeParser
from docx2pdf import convert
from os import rename
import sys
 
# Arguments passed
path = sys.argv[1]
ext = path.split(".")[len(path.split("."))-1]
if ext == "DOCX":
    try:
        rename(path, path.replace("DOCX","docx"))
        path = path.replace("DOCX","docx")
    except:
        print("Rename Failed")

data = ResumeParser(path).get_extracted_data()
info = {}
info["name"] = data["name"] or "null"
info["email"] = data["email"] or "null"
info["mobile_number"] = data["mobile_number"] or "null"
info["skills"] = data["skills"] or "null"

print("["+str(info)+"]")
