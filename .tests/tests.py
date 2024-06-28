#!/usr/bin/env python3

# APP - TESTS
# 2024 (c) Micha Johannes Birklbauer
# https://github.com/michabirklbauer/
# micha.birklbauer@gmail.com

def test1():
    expected = "Starting Template App v0.0.1 ... Hello Luna! Successfully greeted Luna! Template App exited!".split()

    import os
    import subprocess
    if os.name == "nt":
        result = subprocess.run(["App.exe", "--name", "Luna"], stdout = subprocess.PIPE)
    else:
        result = subprocess.run(["./App", "--name", "Luna"], stdout = subprocess.PIPE)
    print(f"GOT$\n{result.stdout.decode("utf-8")}$")
    lines = result.stdout.decode("utf-8").split()
    assert len(lines) == len(expected)
    for i in range(len(expected)):
        assert lines[i].strip() == expected[i].strip()

def test2():
    expected = "Starting Template App v0.0.1 ... Hi Luna! Successfully greeted Luna! Template App exited!".split()

    import os
    import subprocess
    if os.name == "nt":
        result = subprocess.run(["App.exe", "--name", "Luna", "--greeting", "Hi"], stdout = subprocess.PIPE)
    else:
        result = subprocess.run(["./App", "--name", "Luna", "--greeting", "Hi"], stdout = subprocess.PIPE)
    print(f"GOT$\n{result.stdout.decode("utf-8")}$")
    lines = result.stdout.decode("utf-8").split()
    assert len(lines) == len(expected)
    for i in range(len(expected)):
        assert lines[i].strip() == expected[i].strip()
