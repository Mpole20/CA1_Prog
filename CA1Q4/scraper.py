import requests, csv
from bs4 import BeautifulSoup

rooms = []

# first site
soup = BeautifulSoup(requests.get('https://booking-hotels2.tiiny.site/').text, 'lxml')
for hotel in soup.find_all('div', class_='hotel-card'):
    name = hotel.find('div', class_='hotel-name').text.strip()
    price_elem = hotel.find('div', class_='current-price')
    price = price_elem.text.strip().replace('€', '').strip() if price_elem else '0'
    rooms.append([name, price, 'Booking-Hotels2', 'Dec 20-30, 2024'])

# second site  
soup = BeautifulSoup(requests.get('https://hotel1.tiiny.site/').text, 'lxml')
for hotel in soup.find_all('div', class_='hotel-card'):
    name = hotel.find('div', class_='hotel-name').text.strip()
    price_elem = hotel.find('div', class_='current-price')
    price = price_elem.text.strip().replace('€', '').strip() if price_elem else '0'
    rooms.append([name, price, 'Luxe Haven', 'Dec 20-30, 2024'])

# Save to CSV
with open('hotel_rooms.csv', 'w', newline='') as f:
    writer = csv.writer(f)
    writer.writerow(['Hotel Name', 'Price (€)', 'Source Website', 'Seasonal Period'])
    writer.writerows(rooms[:30])  

# Display results
print(f"Found {len(rooms)} rooms for Dec 20-30, 2024:")
print("-" * 80)
with open('hotel_rooms.csv', 'r') as f:
    print(f.read())