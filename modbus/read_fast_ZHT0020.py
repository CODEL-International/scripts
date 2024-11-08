#!/usr/bin/env python3
import minimalmodbus
import time
import os
import sys
import csv
from datetime import datetime

n=len(sys.argv)

if n != 6:
  print("Arguments: COMx Baud Address_Array Timeout Filename")
  quit()

addr = 1
instrument = minimalmodbus.Instrument(sys.argv[1], addr)  # port name, slave address (in decimal)

instrument.serial.baudrate = sys.argv[2]         # Baud
instrument.serial.bytesize = 8
instrument.serial.parity   = minimalmodbus.serial.PARITY_NONE
instrument.serial.stopbits = 1
instrument.serial.timeout  = float(sys.argv[4])          # seconds  0.06 = 60ms
instrument.mode = minimalmodbus.MODE_RTU   # rtu or ascii mode

addresses = sys.argv[3].split(',')
registers = [ 1]
names =     ["mA"]
units =     ["mA"]
info = [
"(mA for Measured mA)",
]

succ = [0,0,0,0]
fail = [0,0,0,0]
lastval = [0,0,0,0]

f = open(sys.argv[5], 'w', newline='')
writer = csv.writer(f, dialect="excel")


while 1:
  for addr in addresses:
    iaddr = int(addr)
    instrument.address = iaddr
    #print ("=== General info about address", addr, "===")
    #print (instrument)
    #print ("=== The registers for address", addr, "===")
    for i in range(len(registers)):
      current_dateTime = datetime.now()
      try:
        values = instrument.read_registers(251, 5)
        #print (str(registers[i]).rjust(3), str(value).rjust(20), units[i].ljust(5), info[i])
        succ[iaddr-1] += 1
        lastval[iaddr-1] = values[0]
        writer.writerow([current_dateTime, '{0:.2f}'.format(lastval[iaddr-1]/100)])
      except:
        fail[iaddr-1] += 1
        writer.writerow([current_dateTime, "misread"])
        
    time.sleep(0.02) # To avoid minimalmodbus.NoResponseError
  os.system('cls')
  print("ET301 Stress-o-Tron 5000 5@251")
  for addr in addresses:
    iaddr = int(addr)
    print (iaddr,":",succ[iaddr-1],"/",fail[iaddr-1],"  ",'{0:.2f}'.format((fail[iaddr-1] / succ[iaddr-1] if succ[iaddr-1] else 1)*100),"% Failure" ,"  Value@251:", '{0:.2f}'.format(lastval[iaddr-1] / 100))
