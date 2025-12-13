import socket
import sqlite3
import uuid

def create_database():
    conn = sqlite3.connect('applications.db')
    cursor = conn.cursor()
    cursor.execute('''
        CREATE TABLE IF NOT EXISTS applications (
            app_number TEXT PRIMARY KEY,
            name TEXT NOT NULL,
            address TEXT NOT NULL,
            qualifications TEXT NOT NULL,
            course TEXT NOT NULL,
            start_year INTEGER,
            start_month INTEGER
        )
    ''')
    conn.commit()
    conn.close()

def generate_app_number():
    return str(uuid.uuid4())[:8].upper()

def handle_client(data, client_address):
    try:
        if data.startswith("LOOKUP|"):
            app_number = data.split("|")[1]
            conn = sqlite3.connect('applications.db')
            cursor = conn.cursor()
            cursor.execute("SELECT * FROM applications WHERE app_number=?", (app_number,))
            result = cursor.fetchone()
            conn.close()
            
            if result:
                return (f"Application Found:\n"
                        f"App Number: {result[0]}\n"
                        f"Name: {result[1]}\n"
                        f"Address: {result[2]}\n"
                        f"Qualifications: {result[3]}\n"
                        f"Course: {result[4]}\n"
                        f"Start Year: {result[5]}\n"
                        f"Start Month: {result[6]}")
            else:
                return "ERROR: Application not found"
        
        fields = data.split('|')
        if len(fields) != 6:
            return "ERROR: Invalid data format"
        
        name, address, qualifications, course, start_year, start_month = fields
        valid_courses = ["MSc in Cyber Security", "MSc Information Systems & computing", "MSc Data Analytics"]
        if course not in valid_courses:
            return "ERROR: Invalid course selection"
        
        app_number = generate_app_number()
        
        conn = sqlite3.connect('applications.db')
        cursor = conn.cursor()
        cursor.execute('''
            INSERT INTO applications (app_number, name, address, qualifications, course, start_year, start_month)
            VALUES (?, ?, ?, ?, ?, ?, ?)
        ''', (app_number, name, address, qualifications, course, int(start_year), int(start_month)))
        conn.commit()
        conn.close()
        
        return f"SUCCESS: Application submitted. Your application number is: {app_number}"
    
    except Exception as e:
        return f"ERROR: {str(e)}"


def main():
    create_database()
    
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind(('localhost', 12345))
    server_socket.listen(5)
    print("Server started on port 12345...")
    
    while True:
        client_socket, client_address = server_socket.accept()
        print(f"Connection from {client_address}")
        
        data = client_socket.recv(4096).decode()
        response = handle_client(data, client_address)
        
        client_socket.send(response.encode())
        client_socket.close()


if __name__ == "__main__":
    main()
