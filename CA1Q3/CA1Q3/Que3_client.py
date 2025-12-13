import socket

def get_user_input():
    print("\n=== DBS Application Form ===")
    name = input("Full Name: ")
    address = input("Address: ")
    qualifications = input("Educational Qualifications: ")
    
    courses = {
        "1": "MSc in Cyber Security",
        "2": "MSc Information Systems & computing", 
        "3": "MSc Data Analytics"
    }
    
    while True:
        print("\nAvailable Courses:")
        for k, v in courses.items():
            print(f"{k}. {v}")
        course_choice = input("Select course (1-3): ")
        course = courses.get(course_choice)
        if course:
            break
        print("Invalid selection. Please enter 1, 2, or 3.")
    
    while True:
        try:
            start_year = int(input("Start Year (2000-2100): "))
            if 2000 <= start_year <= 2100:
                break
            print("Year out of range.")
        except ValueError:
            print("Invalid input. Enter a number.")

    while True:
        try:
            start_month = int(input("Start Month (1-12): "))
            if 1 <= start_month <= 12:
                break
            print("Month out of range.")
        except ValueError:
            print("Invalid input. Enter a number.")
    
    return f"{name}|{address}|{qualifications}|{course}|{start_year}|{start_month}"

def main():
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    try:
        client_socket.connect(('localhost', 12345))
        print("Connected to server successfully!\n")
        
        while True:
            print("=== DBS Application System ===")
            print("1. Create new application")
            print("2. Check application by code")
            print("3. Exit")
            choice = input("Select an option (1-3): ")
            
            if choice == "1":
                data = get_user_input()
                client_socket.send(data.encode())
                response = client_socket.recv(4096).decode()
                print(f"\nServer Response:\n{response}\n")
            
            elif choice == "2":
                app_number = input("Enter your application number: ")
                client_socket.send(f"LOOKUP|{app_number}".encode())
                response = client_socket.recv(4096).decode()
                print(f"\nServer Response:\n{response}\n")
            
            elif choice == "3":
                print("Exiting...")
                break
            
            else:
                print("Invalid option. Try again.\n")
        
    except Exception as e:
        print(f"Error: {e}")
    finally:
        client_socket.close()

if __name__ == "__main__":
    main()
