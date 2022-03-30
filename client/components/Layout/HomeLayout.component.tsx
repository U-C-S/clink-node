import React from "react";
import { Header, QuickBar } from "../Header";
import { Button, Grid } from "@mantine/core";
import { NavigationBar } from "./Navigation";
import { MainContent } from "./Content";
import { Footer } from "./Footer";

export function HomeLayout() {
	return (
		<>
			<Grid
				gutter={40}
				style={{
					width: "70%",
					margin: "0 auto",
				}}>
				<Grid.Col
					span={4}
					style={{
						paddingTop: "0px",
					}}>
					<Header />
				</Grid.Col>

				<Grid.Col
					span={8}
					style={{
						paddingTop: "0px",
						position: "sticky",
						top: "0px",
						left: "0px",
					}}>
					<QuickBar />
				</Grid.Col>

				<Grid.Col span={4}>
					<NavigationBar />
				</Grid.Col>

				<Grid.Col
					span={8}
					style={{
						height: "800px",
					}}>
					<MainContent />
				</Grid.Col>
			</Grid>

			<Footer />
		</>
	);
}
