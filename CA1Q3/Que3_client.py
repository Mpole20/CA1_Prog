import socket

def get_user_input():
    print("=== DBS Application Form ===")
    name = input("Full Name: ")
    address = input("Address: ")
    qualifications = input("Educational Qualifications: ")
    
    print("\nAvailable Courses:")
    print("1. MSc in Cyber Security")
    print("2. MSc Information Systems & computing") 
    print("3. MSc Data Analytics")
    
    course_choice = input("Select course (1-3): ")
    courses = {
        "1": "MSc in Cyber Security",
        "2": "MSc Information Systems & computing", 
        "3": "MSc Data Analytics"
    }
    
    course = courses.get(course_choice, "MSc in Cyber Security")
    start_year = input("Start Year: ")
    start_month = input("Start Month (1-12): ")
    
    return f"{name}|{address}|{qualifications}|{course}|{start_year}|{start_month}"

def main():
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    
    try:
        client_socket.connect(('localhost', 12345))
        print("Connected to server successfully!")
        
        data = get_user_input()
        client_socket.send(data.encode())
        
        response = client_socket.recv(1024).decode()
        print(f"\nServer Response: {response}")
        
    except Exception as e:
        print(f"Error: {e}")
    finally:
        client_socket.close()

if __name__ == "__main__":
    main()