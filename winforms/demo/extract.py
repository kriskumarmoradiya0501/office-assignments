import PyPDF2

def extract_text_from_pdf(pdf_path):
    with open(pdf_path, 'rb') as file:
        reader = PyPDF2.PdfReader(file)
        text = ''
        for i, page in enumerate(reader.pages):
            text += f'--- Page {i+1} ---\n'
            text += page.extract_text() + '\n'
        return text

if __name__ == '__main__':
    text = extract_text_from_pdf('ilovepdf_merged.pdf')
    with open('pdf_content.txt', 'w', encoding='utf-8') as outfile:
        outfile.write(text)
    print("Extracted text to pdf_content.txt")
