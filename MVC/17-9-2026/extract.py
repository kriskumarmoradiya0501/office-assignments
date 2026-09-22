import sys
from pypdf import PdfReader

def extract_text(pdf_path):
    reader = PdfReader(pdf_path)
    text = ""
    for i, page in enumerate(reader.pages):
        text += f"\n--- Page {i+1} ---\n"
        page_text = page.extract_text()
        if page_text:
            text += page_text
    with open("pdf_text_utf8.txt", "w", encoding="utf-8") as f:
        f.write(text)

if __name__ == "__main__":
    extract_text(sys.argv[1])
