#!/usr/bin/env python3
import minimalmodbus
import time
import os
import sys
import csv
from datetime import datetime
from art import *

comPort = "COM11"
addr = 1
addresses = [1,2]
registers = [62]

now = datetime.now()
formatted_date_time = now.strftime("%d_%m_%Y_%H_%M_%S")

instrument = minimalmodbus.Instrument(comPort, addr)  # port name, slave address (in decimal)

instrument.serial.baudrate =  9600 ##sys.argv[2]         # Baud
instrument.serial.bytesize = 8
instrument.serial.parity   = minimalmodbus.serial.PARITY_NONE
instrument.serial.stopbits = 1
instrument.serial.timeout  = 0.2 ##200ms ##float(sys.argv[4])          # seconds  0.06 = 60ms
instrument.mode = minimalmodbus.MODE_RTU   # rtu or ascii mode

succ = [0,0,0,0]
fail = [0,0,0,0]
lastval = [0,0,0,0]

f = open(formatted_date_time + ".csv", 'w', newline='')
writer = csv.writer(f, dialect="excel")



while 1:
  for addr in addresses:
    iaddr = int(addr)
    instrument.address = iaddr
    for i in range(len(registers)):
      current_dateTime = datetime.now()
      try:
        value = values = instrument.read_float(62, 3, 2, 0)
        succ[iaddr-1] += 1
        lastval[iaddr-1] = value
        writer.writerow([current_dateTime, iaddr, '{0:.2f}'.format(lastval[iaddr-1])])
      except:
        fail[iaddr-1] += 1
        writer.writerow([current_dateTime, iaddr, "misread"])      

    time.sleep(0.02) # To avoid minimalmodbus.NoResponseError

  os.system('cls')
  print(text2art("CODEL FastLog"))
  for addr in addresses:
    iaddr = int(addr)
    print (iaddr,":",succ[iaddr-1],"/",fail[iaddr-1],"  ",'{0:.2f}'.format((fail[iaddr-1] / succ[iaddr-1] if succ[iaddr-1] else 1)*100),"% Failure" ,"  Value:", '{0:.2f}'.format(lastval[iaddr-1]), "mV")
