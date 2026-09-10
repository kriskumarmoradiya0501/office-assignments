import fitz  # PyMuPDF

def extract_text_from_pdf(pdf_path):
    doc = fitz.open(pdf_path)
    text = ''
    for i, page in enumerate(doc):
        text += f'--- Page {i+1} ---\n'
        text += page.get_text() + '\n'
    return text

if __name__ == '__main__':
    text = extract_text_from_pdf('ilovepdf_merged.pdf')
    with open('pdf_content_fitz.txt', 'w', encoding='utf-8') as outfile:
        outfile.write(text)
    print("Extracted text to pdf_content_fitz.txt")
